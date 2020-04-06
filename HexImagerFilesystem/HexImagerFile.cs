using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flir.Atlas.Image;
using Flir.Atlas.Image.Playback;
using Accord.Video.FFMPEG;

namespace METEC
{
    public class HexImagerFile : IEnumerable<FLIRImagerFile>
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Instance variables
        private SortedDictionary<int, FLIRImagerFile> _imageFiles = new SortedDictionary<int, FLIRImagerFile>();

        // Constructors
        public HexImagerFile(DateTime timestamp)
        {
            Timestamp = timestamp;
        }

        // Make class enumerable
        public IEnumerator<FLIRImagerFile> GetEnumerator()
        {
            foreach (var image in _imageFiles)
                yield return image.Value;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public FLIRImagerFile this[int index]
        {
            get { return _imageFiles[index]; }
            set
            {
                if (_imageFiles.ContainsKey(index))
                    _imageFiles[index] = value;
                else
                    Add(value);
            }
        }

        // Public properties
        public static string TIMESTAMP_FORMAT = "yyyy-MM-ddTHH-mm-ss-ffffff";

        public DateTime Timestamp { get; private set; }

        public string RecordingType
        {
            get
            {
                if (Extension == ".mp4" || Extension == ".seq")
                    return "Video";
                else if (Extension == ".jpeg")
                    return "Image";
                else if (Extension == "Mixed")
                    return "Mixed";
                else
                    return Extension;
            }
        }

        public string Extension
        {
            get
            {
                var extensions = from flirFile in Values select flirFile.Extension.ToLower();
                if (extensions.Any(ext => ext != extensions.First()))
                    return "Mixed";
                else
                    return extensions.First();
            }
        }

        public int Height //Changed to Height - Marcus
        {
            get
            {
                return (from flirFile in this select flirFile.ImageFile.Width).Max();
            }
        }

        public int Width //Changed to Width - Marcus
        {
            get
            {
                return (from flirFile in this select flirFile.ImageFile.Height).Max();
            }
        }

        // Thermal sequence player properties
        public int SelectedIndex
        {
            get
            {
                return (int)(from flirFile in this select flirFile.ImageFile.ThermalSequencePlayer.SelectedIndex).Average();
            }
            set
            {
                foreach (var flirFile in this)
                {
                    flirFile.ImageFile.ThermalSequencePlayer.SelectedIndex = value;
                }
            }
        }

        public int FrameCount
        {
            get
            {
                return (from flirFile in this select flirFile.ImageFile.Count()).Min();
            }
        }

        public ThermalSequencePlayer.PlayerStatus PlayerStatus
        {
            get
            {
                var status = (from flirFile in this select flirFile.ImageFile.ThermalSequencePlayer.Status).Distinct();
                if (status.Count() > 1)
                    _logger.Warn("Hex Imager File", String.Format("Imager file has multiple player statuses - {0}", status.ToString()));
                return status.First();
            }
        }

        // Thermal sequence player controls
        public void Play()
        {
            foreach (var flirFile in this)
                flirFile.ImageFile.ThermalSequencePlayer.Play();
        }

        public void Pause()
        {
            foreach (var flirFile in this)
                flirFile.ImageFile.ThermalSequencePlayer.Pause();
        }

        public void Stop()
        {
            foreach (var flirFile in this)
                flirFile.ImageFile.ThermalSequencePlayer.Stop();
        }

        public void Next()
        {
            foreach (var flirFile in this)
                flirFile.ImageFile.ThermalSequencePlayer.Next();
        }

        public void Previous()
        {
            foreach (var flirFile in this)
                flirFile.ImageFile.ThermalSequencePlayer.Previous();
        }

        // Open/close image files
        private bool _fileOpen = false;
        public bool FileOpen
        {
            get
            {
                return _fileOpen;
            }
            set
            {
                foreach (var flirImageFile in this)
                {
                    flirImageFile.FileOpen = value;
                    _fileOpen = value;
                }
            }
        }

        // Format item for listview
        public string[] FormatItem()
        {
            string[] item = new string[]
            {
                Timestamp.ToString(),
                RecordingType,
                Count.ToString(),
                Extension
            };

            return item;
        }

        // Overridden IEnumerable members
        public int Count { get { return _imageFiles.Count; } }
        public List<int> Keys { get { return _imageFiles.Keys.ToList(); } }
        public List<FLIRImagerFile> Values { get { return _imageFiles.Values.ToList(); } }
        public bool ContainsKey(int key)
        {
            return _imageFiles.ContainsKey(key);
        }

        // Add image files
        public void Add(FLIRImagerFile imageFile)
        {
            if (imageFile.Index >= 0 && imageFile.Timestamp == Timestamp)
                _imageFiles.Add(imageFile.Index, imageFile);
            else
            {
                _logger.Warn("Hex Imager File", String.Format("Invalid file added to '{0}' - '{1}'", Timestamp, imageFile.Info.Name));
            }
        }

        public void Add(FileInfo info)
        {
            Add(new FLIRImagerFile(info));
        }

        public void Add(List<FileInfo> infoList)
        {
            foreach (var info in infoList)
                Add(info);
        }

        // Remove image files
        public void Remove(int index)
        {
            _imageFiles[index].ImageFile.Dispose();
            _imageFiles.Remove(index);
        }

        public void Clear()
        {
            Dispose();
            _imageFiles.Clear();
        }

        // Release all resources
        public void Dispose()
        {
            foreach (var imageFile in this)
                imageFile.Dispose();
        }

        // Export image file
        private bool _stitch = false;
        private int _exportCompleteCount { get; set; }
        private int _exportTotalCount { get; set; }

        public int ExportCompleteCount
        {
            get
            {
                if (_stitch)
                    return _exportCompleteCount;
                else
                    return (from imageFile in this select imageFile.ExportCompleteCount).Sum();
            }
        }

        public int ExportTotalCount
        {
            get
            {
                if (_stitch)
                    return _exportTotalCount;
                else
                    return (from imageFile in this select imageFile.ExportTotalCount).Sum();
            }
        }

        public void ExportAsVideo(string path, bool stitch = false)
        {
            _stitch = stitch;
            //FileOpen = true;
            if (stitch)
                ExportStitchedVideo(path);
            else
            {
                var tokenSource = new CancellationTokenSource();
                var taskList = new List<Task>();
                try
                {
                    foreach (var imageFile in this)
                    {
                        taskList.Add(Task.Run(() => imageFile.ExportAsVideo(path), tokenSource.Token));
                    }
                    Task.WaitAll(taskList.ToArray());
                }
                finally
                {
                    tokenSource.Cancel();
                }
            }
        }

        public void ExportAsImage(string path, ImageFormat format, bool stitch = false)
        {
            _stitch = stitch;
            // FileOpen = true;
            if (stitch)
                ExportStitchedImage(path, format);
            else
            {
                var tokenSource = new CancellationTokenSource();
                var taskList = new List<Task>();
                try
                {
                    foreach (var imageFile in this)
                    {
                        taskList.Add(Task.Run(() => imageFile.ExportAsImage(path, format), tokenSource.Token));
                    }
                    Task.WaitAll(taskList.ToArray());
                }
                finally
                {
                    tokenSource.Cancel();
                }
            }
        }

        public void ExportAsCSV(string path)
        {
            var tokenSource = new CancellationTokenSource();
            var taskList = new List<Task>();
            try
            {
                foreach (var imageFile in this)
                {
                    taskList.Add(Task.Run(() => imageFile.ExportAsCSV(path), tokenSource.Token));
                }
                Task.WaitAll(taskList.ToArray());
            }
            finally
            {
                tokenSource.Cancel();
            }
        }


        private void ExportStitchedVideo(string path)
        {
            var fileInfo = VideoFilename(RecordingDirectory(path), "avi");
            fileInfo.Directory.Create();

            var writer = new VideoFileWriter();
            writer.Open(fileInfo.FullName, Width * 3, Height * 2, 10, VideoCodec.MPEG4);
            _logger.Info("FLIR Image File", String.Format("Exporting video to - {0}", fileInfo.FullName));

            foreach (var imageFile in this)
                imageFile.ImageFile.EnterLock();

            try
            {
                int oldIndex = SelectedIndex;
                SelectedIndex = 0;

                _exportTotalCount = FrameCount - 1;
                _exportCompleteCount = SelectedIndex;

                while (SelectedIndex < FrameCount)
                {
                    writer.WriteVideoFrame(StitchImages());
                    Next();
                    _exportCompleteCount = SelectedIndex;
                }

                SelectedIndex = oldIndex;
            }
            finally
            {
                foreach (var imageFile in this)
                    imageFile.ImageFile.ExitLock();
                writer.Close();
            }
        }

        private void ExportStitchedImage(string path, ImageFormat format)
        {
            var dirInfo = RecordingDirectory(path);
            dirInfo.Create();
            _logger.Info("Hex Imager File", String.Format("Exporting {0} images to - {1}", format.ToString(), dirInfo.FullName));

            foreach (var imageFile in this)
                imageFile.ImageFile.EnterLock();

            try
            {
                int oldIndex = SelectedIndex;
                SelectedIndex = 0;

                _exportTotalCount = FrameCount;
                _exportCompleteCount = SelectedIndex;

                while (SelectedIndex < FrameCount)
                {
                    var image = StitchImages();
                    var fileInfo = ImageFilename(dirInfo, format.ToString().ToLower(),
                        TimeSpan.FromSeconds((double)SelectedIndex / 10.0));
                    image.Save(fileInfo.FullName, format);
                    Next();
                    _exportCompleteCount = SelectedIndex;
                }

                SelectedIndex = oldIndex;
            }
            finally
            {
                foreach (var imageFile in this)
                    imageFile.ImageFile.ExitLock();
            }
        }

        public Bitmap StitchImages()
        {
            var bitmap = new Bitmap(Width * 3, Height * 2);

            var graphics = Graphics.FromImage(bitmap);

            foreach (var imageFile in this)
            {
                imageFile.ImageFile.EnterLock();

                try
                {
                    int xPos = imageFile.Index % 3 * imageFile.ImageFile.Width;
                    int yPos = imageFile.Index / 3 * imageFile.ImageFile.Height;

                    graphics.DrawImage(imageFile.ImageFile.Image, new Point(xPos, yPos));
                }
                finally
                {
                    imageFile.ImageFile.ExitLock();
                }
            }

            return bitmap;
        }


        public string FileTimestamp(TimeSpan offset = new TimeSpan())
        {
            return (Timestamp + offset).ToString(TIMESTAMP_FORMAT);
        }

        public DirectoryInfo RecordingDirectory(string path)
        {
            return new DirectoryInfo(String.Format(@"{0}\recording_{1}", path, FileTimestamp()));
        }

        public FileInfo VideoFilename(DirectoryInfo path, string extension)
        {
            return new FileInfo(String.Format(@"{0}\video_all_{1}.{2}", path.FullName, FileTimestamp(), extension));
        }

        public FileInfo ImageFilename(DirectoryInfo path, string extension, TimeSpan offset = new TimeSpan())
        {
            return new FileInfo(String.Format(@"{0}\image_all_{1}.{2}", path.FullName, FileTimestamp(offset), extension));
        }
    }
}

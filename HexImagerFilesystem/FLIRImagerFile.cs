using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flir.Atlas.Image;
using Accord.Video.FFMPEG;

namespace METEC
{

    public class FLIRImagerFile
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);
        public static string TIMESTAMP_FORMAT = "yyyy-MM-ddTHH-mm-ss-ffffff";

        public FileInfo Info { get; private set; }
        public ThermalImageFile ImageFile { get; private set; } = new ThermalImageFile();

        // Constructors
        public FLIRImagerFile(FileInfo info)
        {
            Info = info;
        }

        // Open/close file
        public bool FileOpen
        {
            get
            {
                return ImageFile.FileName.Length > 0;
            }
            set
            {
                if (!FileOpen && value)
                {
                    ImageFile = new ThermalImageFile(Info.FullName);
                    ImageFile.Changed += _image_Changed;
                    ImageFile.TemperatureUnitChanged += _image_TemperatureUnitChanged;
                }
                else if (FileOpen)
                {
                    ImageFile.Changed -= _image_Changed;
                    ImageFile.TemperatureUnitChanged -= _image_TemperatureUnitChanged;
                    ImageFile.Close();
                }
            }
        }

        // Public properties
        public int Index
        {
            get
            {
                var nameParts = Info.Name.Split('.')[0].Split('_');
                if (nameParts.Length > 2)
                {
                    if (int.TryParse(nameParts[1], out int index))
                        return index;
                }
                _logger.Info("FLIR Image File", String.Format("Failed to parse index from filename - '{0}'", Info.Name));
                return -1;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                var nameParts = Info.Name.Split('.')[0].Split('_');
                if (nameParts.Length > 2)
                {
                    if (long.TryParse(nameParts[2], out long fileTime))
                        return DateTime.FromFileTime(fileTime);
                    else
                        return DateTime.ParseExact(nameParts[2], TIMESTAMP_FORMAT, null);
                }
                _logger.Info("FLIR Image File", String.Format("Failed to parse timestamp from filename - '{0}'", Info.Name));
                return new DateTime();
            }
        }

        public string RecordingType
        {
            get
            {
                if (Extension == "mp4" || Extension == "seq")
                    return "Video";
                else if (Extension == "jpeg")
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
                return Info.Extension;
            }
        }


        // Thermal image file event handlers
        public event EventHandler<ImageChangedEventArgs> Changed;
        private void _image_Changed(object sender, ImageChangedEventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public event EventHandler<TemperatureUnitEventArgs> TemperatureUnitChanged;
        private void _image_TemperatureUnitChanged(object sender, TemperatureUnitEventArgs e)
        {
            _logger.Debug("FLIR Image File", String.Format("Image {0} temperature unit changed", Index));
            if (TemperatureUnitChanged != null)
                TemperatureUnitChanged(this, e);
        }

        // Export image file
        public int ExportCompleteCount { get; private set; }
        public int ExportTotalCount { get; private set; }

        public void ExportAsVideo(string path)
        {
            var fileInfo = VideoFilename(RecordingDirectory(path), "avi");
            fileInfo.Directory.Create();

            var writer = new VideoFileWriter();
            writer.Open(fileInfo.FullName, ImageFile.Width, ImageFile.Height, (int)ImageFile.ThermalSequencePlayer.FrameRate, VideoCodec.MPEG4);
            _logger.Info("FLIR Image File", String.Format("Exporting video to - {0}", fileInfo.FullName));

            ImageFile.EnterLock();
            try
            {
                int oldIndex = ImageFile.ThermalSequencePlayer.SelectedIndex;
                ImageFile.ThermalSequencePlayer.SelectedIndex = 0;

                ExportTotalCount = ImageFile.Count() - 1;
                ExportCompleteCount = ImageFile.ThermalSequencePlayer.SelectedIndex;

                while (ExportCompleteCount < ExportTotalCount)
                {
                    writer.WriteVideoFrame(ImageFile.Image);
                    ImageFile.ThermalSequencePlayer.Next();
                    ExportCompleteCount = ImageFile.ThermalSequencePlayer.SelectedIndex;
                }

                writer.Close();
                ImageFile.ThermalSequencePlayer.SelectedIndex = oldIndex;
            }
            finally
            {
                ImageFile.ExitLock();
            }
        }

        public void ExportAsCSV(string path)
        {
            var fileInfo = CsvFilename(RecordingDirectory(path), "csv");
            fileInfo.Directory.Create();

            using (var outfile = new StreamWriter(fileInfo.FullName, true))
            {
                _logger.Info("FLIR Image File", String.Format("Exporting CSV to - {0}", fileInfo.FullName));

                ImageFile.EnterLock();
                try
                {
                    int oldIndex = ImageFile.ThermalSequencePlayer.SelectedIndex;
                    ImageFile.ThermalSequencePlayer.SelectedIndex = 0;

                    ExportTotalCount = ImageFile.Count() - 1;
                    ExportCompleteCount = ImageFile.ThermalSequencePlayer.SelectedIndex;

                    while (ExportCompleteCount < ExportTotalCount)
                    {
                        //outfile.Write(String.Format("Frame {0}", ExportCompleteCount));
                        //outfile.Write(Environment.NewLine);
                        var arr = ImageFile.ImageProcessing.GetPixelsArray();
                        for (int i=0; i < arr.GetLength(1);  i++)  //changed to 1 by Marcus
                        {
                            for (int j=0; j < arr.GetLength(0); j++)
                            {
                                // Potentially needs to be scaled by ImageFile.MinSignalValue - ImageFile.MaxSignalValue
                                // var value = (arr[i, j] * (ImageFile.MaxSignalValue - ImageFile.MinSignalValue) / Int16.MaxValue) + ImageFile.MinSignalValue;
                                var value = ImageFile.GetValueAt(new Point(i, j)).Value;
                                outfile.Write(value.ToString() + ',');
                            }
                            outfile.Write(Environment.NewLine);
                        }
                        ImageFile.ThermalSequencePlayer.Next();
                        ExportCompleteCount = ImageFile.ThermalSequencePlayer.SelectedIndex;
                    }

                    ImageFile.ThermalSequencePlayer.SelectedIndex = oldIndex;
                }
                finally
                {
                    ImageFile.ExitLock();
                }
            }
        }

        public void ExportAsImage(string path, ImageFormat format)
        {
            var dirInfo = RecordingDirectory(path);
            dirInfo.Create();
            _logger.Info("Hex Imager File", String.Format("Exporting {0} images to - {1}", format.ToString(), dirInfo.FullName));

            ImageFile.EnterLock();
            try
            {
                int oldIndex = ImageFile.ThermalSequencePlayer.SelectedIndex;
                ImageFile.ThermalSequencePlayer.SelectedIndex = 0;

                ExportTotalCount = ImageFile.Count() - 1;
                ExportCompleteCount = ImageFile.ThermalSequencePlayer.SelectedIndex;

                while (ExportCompleteCount < ExportTotalCount)
                { 
                    var fileInfo = ImageFilename(dirInfo, format.ToString().ToLower(),
                        TimeSpan.FromSeconds((double)ImageFile.ThermalSequencePlayer.SelectedIndex / 10.0));

                    ImageFile.Image.Save(fileInfo.FullName, format);
                    ImageFile.ThermalSequencePlayer.Next();
                    ExportCompleteCount = ImageFile.ThermalSequencePlayer.SelectedIndex;
                }
                ImageFile.ThermalSequencePlayer.SelectedIndex = oldIndex;
            }
            finally
            {
                ImageFile.ExitLock();
            }
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
            return new FileInfo(String.Format(@"{0}\video_{1}_{2}.{3}", path.FullName, Index, FileTimestamp(), extension));
        }

        public FileInfo ImageFilename(DirectoryInfo path, string extension, TimeSpan offset = new TimeSpan())
        {
            return new FileInfo(String.Format(@"{0}\image_{1}_{2}.{3}", path.FullName, Index, FileTimestamp(offset), extension));
        }

        public FileInfo CsvFilename(DirectoryInfo path, string extension, TimeSpan offset = new TimeSpan())
        {
            return new FileInfo(String.Format(@"{0}\camera_{1}_{2}.{3}", path.FullName, Index, FileTimestamp(offset), extension));
        }

        // Release all resources
        public void Dispose()
        {
            FileOpen = false;
            ImageFile.Dispose();
        }
    }
}

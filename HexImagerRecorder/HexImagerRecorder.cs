///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Class to record images from multiple FLIRCamera instances
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Flir.Atlas.Live;
using Flir.Atlas.Image;
using Flir.Atlas.Live.Recorder;

namespace METEC
{
    public class HexImagerRecorder
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Camera manager
        private CameraManager _manager;
        private HexImagerFilesystem _filesystem = new HexImagerFilesystem();
        public SortedDictionary<int, FLIRCameraStatus> ManagerStatus { get { return _manager.CameraStatus; } }

        // Recorder status
        private readonly Stopwatch _recordingTime = new Stopwatch();
        public RecorderState RecorderStatus { get; private set; } = RecorderState.PreRecording;

        public TimeSpan RecordingTime { get { return _recordingTime.Elapsed; } }

        public bool RecordingEnabled { get { return (_manager.NumCameras > 0); } }

        // Directory for writing files to
        public string OutputDirectory { get { return _filesystem.Path; } set { _filesystem.Path = value; } }

        // Constructor
        public HexImagerRecorder(string outputDirectory="")
        {
            if (outputDirectory.Length > 0)
                OutputDirectory = outputDirectory;
            else
                OutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\";
            // _filesystem = new HexImagerFilesystem(OutputDirectory);
        }

        public HexImagerRecorder(CameraManager manager, string outputDirectory="")
        {
            if (outputDirectory.Length > 0)
                OutputDirectory = outputDirectory;
            else
                OutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\";

            Initialize(manager);
        }

        // Initialize recorder with cameras
        public void Initialize(CameraManager manager)
        {
            _manager = manager;
            _manager.ConnectionStatusChanged += _manager_ConnectionStatusChanged;
            _manager.SettingsChanged += _manager_SettingsChanged;
        }

        // Dispose all recorder components
        public void Dispose()
        {
            _manager.ConnectionStatusChanged -= _manager_ConnectionStatusChanged;
            _manager.SettingsChanged += _manager_SettingsChanged;

            _manager.Dispose();
        }

        // Event handler for connection status changed on any camera
        public event EventHandler<ConnectionStatusChangedEventArgs> ConnectionStatusChanged;
        private void _manager_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs e)
        {
            _logger.Debug("METEC Recorder", String.Format("Camera {0} connection status changed - {1}", (sender as FLIRCamera).Index, e.Status));
            if (ConnectionStatusChanged != null)
                ConnectionStatusChanged(sender, e);
        }

        public event EventHandler<FLIRCameraSettingsEventArgs> SettingsChanged;
        private void _manager_SettingsChanged(object sender, FLIRCameraSettingsEventArgs settings)
        {
            _logger.Debug("METEC Recorder", "Camera settings changed");
            if (SettingsChanged != null)
                SettingsChanged(sender, settings);
        }

        // Time span recording options
        public bool TimeSpanEnabled { get; private set; }
        public TimeSpan RecorderTimeSpan { get; private set; }

        public void EnableTimeSpan(TimeSpan timeSpan)
        {
            foreach (var camera in _manager)
                camera.Recorder.EnableTimeSpan(timeSpan);
            TimeSpanEnabled = true;
            RecorderTimeSpan = timeSpan;
        }

        public void DisableTimeSpan()
        {
            foreach (var camera in _manager)
                camera.Recorder.DisableTimeSpan();
            TimeSpanEnabled = false;
            RecorderTimeSpan = new TimeSpan();
        }

        public bool PreRecordingEnabled { get; private set; }

        public void EnablePreRecording(int numFrames)
        {
            if (PreRecordingAllowed())
            {
                foreach (var camera in _manager)
                {
                    (camera.Recorder as ThermalImageRecorder).EnablePreRecording(numFrames);
                }
            }
            else
                throw new Exception("Pre-recording only allowed on thermal image recorders.");
        }

        public void DisablePreRecording()
        {
            foreach (var camera in _manager)
            {
                if (camera.Recorder is ThermalImageRecorder)
                    (camera.Recorder as ThermalImageRecorder).DisablePreRecording();
            }
        }

        public bool PreRecordingAllowed()
        {
            foreach (var camera in _manager)
            {
                if (!(camera.Recorder is ThermalImageRecorder))
                    return false;
            }
            return true;
        }

        public Dictionary<int, int> FrameCount()
        {
            var frameCount = new Dictionary<int, int>();
            foreach (var camera in _manager)
                frameCount.Add(camera.Index, camera.Recorder.FrameCount);

            return frameCount;
        }

        public int TotalFrameCount()
        {
            int frameCount = 0;
            foreach (var count in FrameCount())
                frameCount += count.Value;

            return frameCount;
        }

        public Dictionary<int, int> LostImageCount()
        {
            var lostImages = new Dictionary<int, int>();
            foreach (var camera in _manager)
                lostImages.Add(camera.Index, camera.Recorder.LostImages);

            return lostImages;
        }

        public int TotalLostImageCount()
        {
            int lostImages = 0;
            foreach (var count in LostImageCount())
                lostImages += count.Value;

            return lostImages;
        }

        // Recording operations
        private DateTime CurrentFileTime;
        public void TakeSnapshot()
        {
            CurrentFileTime = DateTime.Now;
            IEnumerable<KeyValuePair<int, ImageBase>> images = from camera in _manager.Where(cam => cam.RecordingEnabled)
                                            select new KeyValuePair<int, ImageBase>(camera.Index, _camera_TakeSnapshot(camera));
            foreach (var image in images)
            {
                if (image.Value != null)
                {
                    string fname = _filesystem.CreateFileName(image.Key, CurrentFileTime, ".jpg");
                    _logger.Info("METEC Recorder", String.Format("Saving image to file - {0}", fname));
                    image.Value.SaveSnapshot(fname);
                }
                else
                    _logger.Warn("METEC Recorder", String.Format("Null image at index - {0}", image.Key));
            }
        }

        private ImageBase _camera_TakeSnapshot(FLIRCamera camera)
        {
            ImageBase image = null;

            camera.GetImage().EnterLock();
            try
            {
                // CameraFeed1.Image = _manager.GetImage(index).Image;
                image = camera.GetImage();
            }
            catch (Exception exception)
            {
                _logger.Error("METEC Recorder", exception.Message);
            }
            finally
            {
                camera.GetImage().ExitLock();
            }
            return image;
        }

        public bool StartRecording()
        {
            if (RecorderStatus == RecorderState.Stopped || RecorderStatus == RecorderState.PreRecording)
            {
                // Start recording
                CurrentFileTime = DateTime.Now;

                foreach (var camera in _manager)
                {
                    _logger.Info("Recorder Form", String.Format("Starting recording on camera {0}", camera.Index));
                    camera.Recorder.Start(_filesystem.CreateFileName(camera.Index, CurrentFileTime, camera.Recorder.Extension));
                }

                RecorderStatus = RecorderState.Recording;
                _recordingTime.Start();
                return true;
            }
            else return false;
        }

        public bool PauseRecording()
        {
            if (RecorderStatus == RecorderState.Recording)
            {
                _logger.Info("Recorder Form", "Pausing recording");
                _manager.ToList().ForEach(camera => camera.Recorder.Pause());
                RecorderStatus = RecorderState.Paused;
                return true;
            }
            else return false;
        }

        public bool ContinueRecording()
        {
            if (RecorderStatus == RecorderState.Paused)
            {
                _logger.Info("Recorder Form", "Continuing recording");
                _manager.ToList().ForEach(camera => camera.Recorder.Continue());
                RecorderStatus = RecorderState.Recording;
                return true;
            }
            else return false;
        }

        public bool StopRecording()
        {
            if (RecorderStatus == RecorderState.Recording || RecorderStatus == RecorderState.Paused)
            {
                foreach (var camera in _manager)
                {
                    _logger.Info("Recorder Form", String.Format("Stopping recording on camera {0}", camera.Index));
                    camera.Recorder.Stop();
                }
                _recordingTime.Stop();
                RecorderStatus = RecorderState.Stopped;
                return true;
            }
            else return false;
        }
        /*
        private string CreateFileName(int index, DateTime timestamp, string extension)
        {
            string timestampString = timestamp.ToFileTime().ToString("D19");
            return OutputDirectory + string.Format("camera_{0}_{1}", index, timestampString) + extension;
        }
        */
    }
}

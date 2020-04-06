///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Windows form to manage HexImagerRecorder
///-----------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Flir.Atlas.Live;
using Flir.Atlas.Live.Recorder;

namespace METEC
{
    public partial class HexImagerRecorderForm : Form
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Recorder instance
        private HexImagerRecorder _recorder = new HexImagerRecorder();
        private readonly Timer _timer = new Timer();

        // Constructors
        public HexImagerRecorderForm()
        {
            InitializeComponent();
            outputPathLabel.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\";
            _recorder.OutputDirectory = outputPathLabel.Text;

            hexImagerFileSelectControl.Initialize(outputPathLabel.Text);
            hexImagerFileSelectControl.SelectedFileMouseDoubleClick += recordingsListView_MouseDoubleClick;

            hexImagerFileSelectControl.UpdateListView();
        }

        public HexImagerRecorderForm(CameraManager manager)
        {
            InitializeComponent();
            outputPathLabel.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\";
            _recorder.OutputDirectory = outputPathLabel.Text;
            Initialize(manager);

            hexImagerFileSelectControl.Initialize(outputPathLabel.Text);
            hexImagerFileSelectControl.SelectedFileMouseDoubleClick += recordingsListView_MouseDoubleClick;

            hexImagerFileSelectControl.UpdateListView();
        }

        // Recorder form controls
        private void Initialize(CameraManager manager)
        {
            _recorder.Initialize(manager);
            _recorder.ConnectionStatusChanged += _recorder_ConnectionStatusChanged;
            _recorder.SettingsChanged += _recorder_SettingsChanged;

            UpdateCameraListView();
            UpdateGUI();

            _timer.Interval = 110;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private new void Dispose()
        {
            _timer.Stop();

            _recorder.Dispose();
        }

        // Recorder event delegates
        private bool _connectionStatusChanged = false;
        private void _recorder_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs e)
        {
            // UpdateCameraListView();
            _connectionStatusChanged = true;
        }

        private bool _settingsChanged = false;
        private void _recorder_SettingsChanged(object sender, FLIRCameraSettingsEventArgs settings)
        {
            // UpdateCameraListView();
            _settingsChanged = true;
        }

        // Refresh status data
        void _timer_Tick(object sender, EventArgs e)
        {
            UpdateRecorderStatus();

            if (_connectionStatusChanged || _settingsChanged)
            {
                UpdateCameraListView();
                UpdateGUI();

                _connectionStatusChanged = false;
                _settingsChanged = false;
            }
        }

        private void UpdateGUI()
        {
            preRecordingGroupBox.Enabled = _recorder.PreRecordingAllowed();

            if (_recorder.RecordingEnabled)
            {
                recordButton.Enabled = true;
                pauseButton.Enabled = true;
                recSpeedGroupBox.Enabled = true;
            }
            else
            {
                recordButton.Enabled = false;
                pauseButton.Enabled = false;
                recSpeedGroupBox.Enabled = false;
            }
        }

        private void UpdateRecorderStatus()
        {
            if (_recorder == null) return;

            statusLabel.Text = _recorder.RecorderStatus.ToString();
            imageCountLabel.Text = _recorder.TotalFrameCount().ToString();
            lostImagesLabel.Text = _recorder.TotalLostImageCount().ToString();
            elapsedTimeLabel.Text = _recorder.RecordingTime.ToString();
        }

        private void UpdateCameraListView()
        {
            cameraStatusListView.Items.Clear();
            var cameraStatus = _recorder.ManagerStatus;
            foreach (var status in cameraStatus)
            {
                Console.Write(status.ToString());
                string sensitivity;
                if (status.Value.HighSensitivity)
                    sensitivity = "High";
                else
                    sensitivity = "Low";

                string[] labels = new string[] { String.Format("{0} {1}", status.Value.Name, status.Key),
                    status.Value.CameraConnectionStatus.ToString(), sensitivity, status.Value.FrameRate,
                    status.Value.Resolution.ToString()};

                var lv = new ListViewItem(labels, status.Key);
                cameraStatusListView.Items.Add(lv);
            }
        }

        /*
        private void UpdateRecordingListView()
        {
            recordingsListView.Items.Clear();

            var sequenceMap = MapFilenames(".seq");

            foreach (var fileSet in sequenceMap)
            {
                var lv = new ListViewItem(String.Format("Sequence {0}", fileSet.Key)) { Tag = fileSet.Value };
                recordingsListView.Items.Add(lv);
            }

            var videoMap = MapFilenames(".mp4");

            foreach (var fileSet in videoMap)
            {
                var lv = new ListViewItem(String.Format("Video {0}", fileSet.Key)) { Tag = fileSet.Value };
                recordingsListView.Items.Add(lv);
            }

            var imageMap = MapFilenames(".jpg");

            foreach (var fileSet in imageMap)
            {
                var lv = new ListViewItem(String.Format("Image {0}", fileSet.Key)) { Tag = fileSet.Value };
                recordingsListView.Items.Add(lv);
            }
        }
        */
        public SortedDictionary<DateTime, SortedSet<string>> MapFilenames(string extension)
        {
            var directoryMap = new SortedDictionary<DateTime, SortedSet<string>>();
            var directoryInfo = new DirectoryInfo(outputPathLabel.Text);
            // Nasty regex to find only our filenames in directory
            // var filenames = directory.GetFiles(@"camera_.*_[0-9]{4}-(0[1-9]|1[0-2])-([0-2][0-9]|3[0-1])T(2[0-3]|[01][0-9])([0-5][0-9]){2}[0-9]{6}(\.seq|\.mp4)");
            var files = directoryInfo.GetFiles(String.Format("*{0}", extension)); // ("*_[0-9]{19}*");

            foreach (var fileInfo in files)
            {
                string[] nameParts = fileInfo.Name.Split('.')[0].Split('_');

                if (long.TryParse(nameParts[nameParts.Length - 1], out long fileTime))
                {
                    var timestamp = DateTime.FromFileTime(fileTime);
                    if (directoryMap.ContainsKey(timestamp))
                    {
                        directoryMap[timestamp].Add(fileInfo.FullName);
                    }
                    else
                    {
                        var fileSet = new SortedSet<string>();
                        fileSet.Add(fileInfo.FullName);
                        directoryMap.Add(timestamp, fileSet);
                    }
                }
                else
                {
                    _logger.Warn("Recorder form",
                        String.Format("Unable to parse file time '{0}' from file - '{1}'",
                        nameParts[nameParts.Length - 1], fileInfo.Name));
                }
            }

            return directoryMap;
        }

        // Output path controls
        private void browseButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                outputPathLabel.Text = dialog.SelectedPath;
                if (_recorder != null)
                    _recorder.OutputDirectory = dialog.SelectedPath;
            }
        }

        // Recording controls
        private DateTime CurrentFileTime;

        private void snapshotButton_Click(object sender, EventArgs e)
        {
            _recorder.TakeSnapshot();
            hexImagerFileSelectControl.UpdateListView();
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            if (_recorder.RecorderStatus == RecorderState.Stopped || _recorder.RecorderStatus == RecorderState.PreRecording)
            {
                // Start recording
                CurrentFileTime = DateTime.Now;

                if (recSpeedIntervalRadioButton.Checked)
                {
                    _logger.Info("Recorder Form", "Starting recording...");

                    if (int.TryParse(timeSpanTextBox.Text, out int spanSeconds))
                        _recorder.EnableTimeSpan(TimeSpan.FromSeconds(spanSeconds));
                    else
                    {
                        _logger.Warn("Recorder Form", String.Format("Error parsing time span - {0}", timeSpanTextBox.Text));
                        MessageBox.Show("Error parsing time span");
                        return;
                    }
                }
                else if (_recorder.TimeSpanEnabled)
                {
                    _recorder.DisableTimeSpan();
                }

                _recorder.StartRecording();
                recordButton.Text = "Stop";
            }
            else
            {
                _recorder.StopRecording();
                recordButton.Text = "Rec";
            }
            hexImagerFileSelectControl.UpdateListView();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            switch (_recorder.RecorderStatus)
            {
                case RecorderState.Recording:
                    _logger.Info("Recorder Form", "Pausing recording");
                    _recorder.ContinueRecording();
                    pauseButton.Text = "Continue";
                    break;
                case RecorderState.Paused:
                    _logger.Info("Recorder Form", "Continuing recording");
                    _recorder.ContinueRecording();
                    pauseButton.Text = "Pause";
                    break;
            }
        }

        private void preRecordingCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (preRecordingCheckBox.Checked)
            {
                if (int.TryParse(numFramesPreRecTextBox.Text, out int numFrames))
                    _recorder.EnablePreRecording(numFrames);
                else
                {
                    _logger.Warn("Recorder Form", String.Format("Error parsing pre-recording frames - {0}", numFramesPreRecTextBox.Text));
                    MessageBox.Show("Error parsing number of frames to pre-record.");
                }
            }
            else
            {
                _recorder.DisablePreRecording();
            }
        }

        // Recording viewer event delegate
        public event EventHandler<HexImagerFileSelectedEventArgs> SelectedFileMouseDoubleClick;
        private void recordingsListView_MouseDoubleClick(object sender, HexImagerFileSelectedEventArgs e)
        {
            if (SelectedFileMouseDoubleClick != null)
                SelectedFileMouseDoubleClick(this, e);
        }

        private void METECRecorderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // e.Cancel = true;
            // Hide();
        }
    }

    // Event Args for Selected file event
    public class SelectedFileEventArgs : EventArgs
    {
        // The full path to the file.
        public string FilePath { get; private set; }

        internal SelectedFileEventArgs(string path)
        {
            FilePath = path;
        }
    }
}

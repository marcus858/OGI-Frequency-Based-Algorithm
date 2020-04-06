using System;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using Flir.Atlas.Live.Device;

namespace METEC
{
    public partial class TestMainForm : Form
    {
        private CameraManager _manager = new CameraManager();
        private Timer _updateTimer = new Timer();

        public TestMainForm()
        {
            InitializeComponent();

            _manager.DeviceError += _manager_DeviceError;
            _updateTimer.Tick += UpdateFeed;
            _updateTimer.Interval = 20;
            _updateTimer.Start();
        }

        private void connectCamera1_Click(object sender, EventArgs e)
        {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 0);
                connectCamera1.Enabled = false;
                disconnectCamera1.Enabled = true;
                startCamera1.Enabled = true;
                settingsCamera1.Enabled = true;
                metecCameraTemperatureControl1.Initialize(_manager.Camera(0));
                metecCameraFocusControl1.Initialize(_manager.Camera(0));
            }
        }

        private void connectCamera2_Click(object sender, EventArgs e)
        {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 1);
                connectCamera2.Enabled = false;
                disconnectCamera2.Enabled = true;
                // startCamera2.Enabled = true;
                settingsCamera2.Enabled = true;
            }
        }

        private void disconnectCamera1_Click(object sender, EventArgs e)
        {
            _manager.DisconnectCamera(0);
            _manager.DisposeCamera(0);
            connectCamera1.Enabled = true;
            disconnectCamera1.Enabled = false;
            startCamera1.Enabled = false;
            settingsCamera1.Enabled = false;
        }

        private void disconnectCamera2_Click(object sender, EventArgs e)
        {
            _manager.DisconnectCamera(1);
            _manager.DisposeCamera(1);
            connectCamera2.Enabled = true;
            disconnectCamera2.Enabled = false;
            // startCamera2.Enabled = false;
            settingsCamera2.Enabled = false;
        }

        private void UpdateFeed(object sender, EventArgs e)
        {
            // Image[] imgs = new Image[2];
            foreach (var camera in _manager)
            {
                // if (!_manager.NewImage(index)) continue;
                camera.GetImage().EnterLock();
                try
                {
                    var image = camera.GetImage().Image;
                    switch (camera.Index)
                    {
                        case 0:
                            CameraFeed1.Image = image;
                            break;
                        case 1:
                            CameraFeed2.Image = image;
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Trace.TraceError(exception.Message);
                }
                finally
                {
                    camera.GetImage().ExitLock();
                }
            }
        }

        HexImagerRecorderForm _recorder;
        private void startCamera1_Click(object sender, EventArgs e)
        {
            var compass = _manager.Camera(0).GeoLocation.GetCompassInfo();
            var gps = _manager.Camera(0).GeoLocation.GetGpsInfo();
            Console.WriteLine(gps);

            _recorder = new HexImagerRecorderForm(_manager);
            _recorder.SelectedFileMouseDoubleClick += _recorder_SelectedFileMouseDoubleClick;
            _recorder.Show();
            _recorder.Focus();
        }

        private void startCamera2_Click(object sender, EventArgs e)
        {
            _recorder = new HexImagerRecorderForm(_manager);
            _recorder.SelectedFileMouseDoubleClick += _recorder_SelectedFileMouseDoubleClick;
            _recorder.Show();
            _recorder.Focus();
        }

        void _manager_DeviceError(object sender, Flir.Atlas.Live.Device.DeviceErrorEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage);
        }

        void _recorder_SelectedFileMouseDoubleClick(object sender, HexImagerFileSelectedEventArgs e)
        {
            var playback = new HexImagerViewerForm(e.Recordings[0]);
            playback.Show();
        }

        private void stopCamera1_Click(object sender, EventArgs e) { }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updateTimer != null)
                _updateTimer.Stop();
            if (_recorder != null)
                _recorder.Dispose();
            if (_manager != null)
            {
                _manager.Disconnect();
                _manager.Dispose();
            }
        }

        private void settingsCamera1_Click(object sender, EventArgs e)
        {

            // _logger.Info("Camera Manager", String.Format("Querying settings for camera: {0}", index));
            FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(0));
            settings.ApplySettingsEvent += _manager.ApplySettings;
            settings.Show();
            settings.Focus();
        }

        private void settingsCamera2_Click(object sender, EventArgs e)
        {
            FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(1));
            settings.ApplySettingsEvent += _manager.ApplySettings;
            settings.Show();
            settings.Focus();
        }
    }
}

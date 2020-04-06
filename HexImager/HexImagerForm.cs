using System;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using Flir.Atlas.Image;

namespace METEC
{
    public partial class HexImagerForm : Form
    {
        private CameraManager _manager = new CameraManager();
        public Timer _updateTimer = new Timer();

        public HexImagerForm()
        {

            InitializeComponent();
            
            _updateTimer.Tick += UpdateFeed;
            _updateTimer.Interval = 20;
            _updateTimer.Start();
        }


        public void UpdateFeed(object sender, EventArgs e)
        {
            // Image[] imgs = new Image[4];
            foreach (var camera in _manager)
            {
                // if (!_manager.NewImage(index)) continue;
                camera.GetImage().EnterLock();
                try
                {
                    // CameraFeed1.Image = _manager.GetImage(index).Image; 
                    ImageBase image = camera.GetImage();

                    switch (camera.Index)
                    {
                        case 0:
                            CameraFeed1.Image = image.Image;
                            break;
                    }
                    switch (camera.Index)
                    {
                        case 1:
                            CameraFeed2.Image = image.Image;
                            break;
                    }
                    switch (camera.Index)
                    {
                        case 2:
                            CameraFeed3.Image = image.Image;
                            break;
                    }
                    switch (camera.Index)
                    {
                        case 3:
                            CameraFeed4.Image = image.Image;
                            break;
                    }
                    switch (camera.Index)
                    {
                        case 4:
                            CameraFeed5.Image = image.Image;
                            break;
                    }
                    switch (camera.Index)
                    {
                        case 5:
                            CameraFeed6.Image = image.Image;
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

        

        void _recorder_SelectedFileMouseDoubleClick(object sender, HexImagerFileSelectedEventArgs e)
        {
            var playback = new HexImagerViewerForm(e.Recordings[0]);
            playback.Show();
        }

        

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
        



        public void ConnectCam1_Click(object sender, EventArgs e)
        {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 0);
                ConnectCam1.Enabled = false;
                DisconnectCam1.Enabled = true;
               
                SettingsCam1.Enabled = true;
            }
        }
        public void ConnectCam2_Click(object sender, EventArgs e)
        {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 1);
                ConnectCam2.Enabled = false;
                DisconnectCam1.Enabled = true;
                
                SettingsCam1.Enabled = true;
            }
        }
        public void ConnectCamera3_Click(object sender, EventArgs e)
        {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 2);
                ConnectCamera3.Enabled = false;
                DisconnectCamera3.Enabled = true;
                SettingsCamera3.Enabled = true;
            }
        }
        public void ConnectCamera4_Click(object sender, EventArgs e)
        {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 3);
                ConnectCamera4.Enabled = false;
                DisconnectCamera4.Enabled = true;
              
                SettingsCamera4.Enabled = true;
            }
        }
        public void ConnectCamera5_Click(object sender, EventArgs e)
          {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 4);
                ConnectCamera5.Enabled = false;
                DisconnectCamera5.Enabled = true;
              
                SettingsCamera5.Enabled = true;
            }
        }
        public void ConnectCamera6_Click(object sender, EventArgs e)
          {
            var discoveryDlg = new DiscoveryForm();
            if (discoveryDlg.ShowDialog() == DialogResult.OK)
            {
                _manager.ConnectCamera(discoveryDlg.SelectedCameraDevice, 5);
                ConnectCamera6.Enabled = false;
                DisconnectCamera6.Enabled = true;
               
                SettingsCamera6.Enabled = true;
            }
          }




        private void DisconnectCam1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(0) != null)
                {
                    _manager.DisconnectCamera(0);
                    _manager.DisposeCamera(0);
                    ConnectCam1.Enabled = true;
                    DisconnectCam1.Enabled = false;
                    SettingsCam1.Enabled = false;
                }
            }
            catch
            { return; }
        }
        private void DisconnectCam2_Click(object sender, EventArgs e)
        {

            try
            {
                if (_manager.Camera(1) != null)
                {
                    _manager.DisconnectCamera(1);
                    _manager.DisposeCamera(1);
                    ConnectCam2.Enabled = true;
                    DisconnectCam2.Enabled = false;
                    SettingsCam2.Enabled = false;
                }
            }
            catch
            { return; }
        }
        private void DisconnectCamera3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(2) != null)
                {
                    _manager.DisconnectCamera(2);
                    _manager.DisposeCamera(2);
                    ConnectCamera3.Enabled = true;
                    DisconnectCamera3.Enabled = false;

                    SettingsCamera3.Enabled = false;
                }
            }
            catch
            { return; }
        }
        private void DisconnectCamera4_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(3) != null)
                {
                    _manager.DisconnectCamera(3);
                    _manager.DisposeCamera(3);
                    ConnectCamera4.Enabled = true;
                    DisconnectCamera4.Enabled = false;
                    Record.Enabled = false;
                    SettingsCamera4.Enabled = false;
                }
            }
            catch
            { return; }
        }
        private void DisconnectCamera5_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(4) != null)
                {
                    _manager.DisconnectCamera(4);
                    _manager.DisposeCamera(4);
                    ConnectCamera5.Enabled = true;
                    DisconnectCamera5.Enabled = false;
                    SettingsCamera4.Enabled = false;
                }
            }
            catch
            { return; }

        }
        private void DisconnectCamera6_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(5) != null)
                {
                    _manager.DisconnectCamera(5);
                    _manager.DisposeCamera(5);
                    ConnectCamera6.Enabled = true;
                    DisconnectCamera6.Enabled = false;
                    SettingsCamera6.Enabled = false;
                }
            }
            catch
            { return; }

        }





        private void SettingsCam1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(0) != null)
                {
                    FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(0));
                    settings.ApplySettingsEvent += _manager.ApplySettings;
                    settings.Show();
                    settings.Focus();
                }
            }
            catch
            { return; }
        }
        private void SettingsCam2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(1) != null)
                {
                    FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(1));
                    settings.ApplySettingsEvent += _manager.ApplySettings;
                    settings.Show();
                    settings.Focus();
                }
            }
            catch
            { return; }
        }
        private void SettingsCamera3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(2) != null)
                {

                    FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(2));
                    settings.ApplySettingsEvent += _manager.ApplySettings;
                    settings.Show();
                    settings.Focus();
                }
            }
            catch
            { return; }
        }
        private void SettingsCamera4_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(3) != null)
                {
                    FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(3));
                    settings.ApplySettingsEvent += _manager.ApplySettings;
                    settings.Show();
                    settings.Focus();
                }
            }
            catch
            { return; }
        }
        private void SettingsCamera5_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(4) != null)
                {
                    FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(4));
                    settings.ApplySettingsEvent += _manager.ApplySettings;
                    settings.Show();
                    settings.Focus();
                }
            }
            catch
            { return; }
        }
        private void SettingsCamera6_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(5) != null)
                {
                    FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(5));
                    settings.ApplySettingsEvent += _manager.ApplySettings;
                    settings.Show();
                    settings.Focus();
                }
            }
            catch
            { return; }
        }






        HexImagerRecorderForm _recorder;
        private void Record_Click(object sender, EventArgs e)
        {
            _recorder = new HexImagerRecorderForm(_manager);
            _recorder.SelectedFileMouseDoubleClick += _recorder_SelectedFileMouseDoubleClick;
            _recorder.Show();
            _recorder.Focus();
        }     
       



        public void CameraFeed1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(0) != null)
                {
                    var singlecam = new SingleCamera(_manager, 0);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void CameraFeed2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(1) != null)
                {
                    var singlecam = new SingleCamera(_manager, 1);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void CameraFeed3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(2) != null)
                {
                    var singlecam = new SingleCamera(_manager, 2);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void CameraFeed4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(3) != null)
                {
                    var singlecam = new SingleCamera(_manager, 3);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void CameraFeed5_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(4) != null)
                {
                    var singlecam = new SingleCamera(_manager, 4);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void CameraFeed6_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(5) != null)
                {
                    var singlecam = new SingleCamera(_manager, 5);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void SingleCamView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(0) != null)
                {
                    var singlecam = new SingleCamera(_manager, 0);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void SingleCamView2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (_manager.Camera(1) != null)
                    {
                        var singlecam = new SingleCamera(_manager, 1);
                        singlecam.Show();
                    }
                }
                catch
                { return; }
            }
        }
        private void SingleCam3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(2) != null)
                {
                    var singlecam = new SingleCamera(_manager, 2);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void SingleCamView4_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(3) != null)
                {
                    var singlecam = new SingleCamera(_manager, 3);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void SingleCamView5_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(4) != null)
                {
                    var singlecam = new SingleCamera(_manager, 4);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }
        private void SingleCamView6_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.Camera(5) != null)
                {
                    var singlecam = new SingleCamera(_manager, 5);
                    singlecam.Show();
                }
            }
            catch
            { return; }
        }



        private void ImageViewer_Click(object sender, EventArgs e)
        {
            var playback = new HexImagerViewerForm();
            playback.Show();
        }
    }

}

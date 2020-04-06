///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Windows forms user control for camera focus
///-----------------------------------------------------------------

using Flir.Atlas.Live;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Remote;
using System;
using System.Windows.Forms;

namespace METEC
{
    public partial class FLIRCameraFocusControl : UserControl
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Camera instance
        private FLIRCamera _camera;
        private Timer _timer = new Timer();

        // Constructor
        public FLIRCameraFocusControl()
        {
            InitializeComponent();
        }

        // Initialize with camera instance
        public void Initialize(FLIRCamera camera)
        {
            _camera = camera;
            _camera.ConnectionStatusChanged += _camera_ConnectionStatusChanged;

			UpdateDisplay();
            _timer.Tick += _timer_UpdateDisplay;
            _timer.Interval = 50;
            _timer.Start();
        }
        
        // Update with camera connection status
        private void _camera_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs e)
        {
            _logger.Info("Focus Control", String.Format("Camera {0} connection status changed {1}", _camera.Index, e.Status));
            _camera_Updated = true;
        }

        private bool _camera_Updated = false;
        private void _timer_UpdateDisplay(object sender, EventArgs e)
        {
            if (_camera_Updated)
            {
                UpdateDisplay();
                _camera_Updated = false;
            }
        }

        // Update display values
        private void UpdateDisplay()
        {
            if (_camera.CameraConnectionStatus == ConnectionStatus.Connected)
            {
                if (_camera.Focus.IsSupported())
                {
                    groupBoxFocus.Enabled = true;
                    try
                    {
                        textBoxDistance.Text = String.Format("{0:0.00}", _camera.Focus.GetDistance());
                    }
                    catch (Exception)
                    {
                        textBoxDistance.Enabled = false;
                        buttonFocusDistance.Enabled = false;
                    }
                }
                else
                    groupBoxFocus.Enabled = false;
            }
            else
                groupBoxFocus.Enabled = false;
        }

        // Set automatic focus mode
        private void buttonFocusAuto_Click(object sender, EventArgs e)
        {
            _camera.Focus.Mode(FocusMode.Auto);
        }

        // Set focus distance
        private void buttonFocusDistance_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxDistance.Text, out double distance))
                try
                {
                    _camera.Focus.SetDistance(distance);
                }
                catch (InvalidOperationException exception)
                {
                    // MessageBox.Show("Focus Control", "Set focus distance failed!");
                    _logger.Warn("Focus Control", String.Format("Camera {0} set distance failed: {1}", _camera.Index, exception.Message));
                }
            else
                MessageBox.Show("Focus Control", "Invalid distance value!");
        }

        // Set focus to near
        private void buttonFocusNear_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _camera.Focus.Mode(FocusMode.Near);
            }
            catch (InvalidOperationException exception)
            {
                // MessageBox.Show("Focus Control", "Focus command failed!");
                _logger.Warn("Focus Control", String.Format("Camera {0} set near focus failed: {1}", _camera.Index, exception.Message));
            }
        }

        // Set focus to far
        private void buttonFocusFar_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _camera.Focus.Mode(FocusMode.Far);
            }
            catch (InvalidOperationException exception)
            {
                // MessageBox.Show("Focus Control", "Focus command failed!");
                _logger.Warn("Focus Control", String.Format("Camera {0} set far focus failed: {1}", _camera.Index, exception.Message));
            }
        }

        // Stop camera focusing
        private void _camera_StopFocus(object sender, EventArgs e)
        {
            try
            {
                _camera.Focus.Mode(FocusMode.Stop);
            }
            catch (InvalidOperationException exception)
            {
                // MessageBox.Show("Focus Control", "Focus command failed!");
                _logger.Warn("Focus Control", String.Format("Camera {0} set stop focus failed: {1}",_camera.Index, exception.Message));
            }
        }
    }
}

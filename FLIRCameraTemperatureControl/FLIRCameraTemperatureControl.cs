///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Windows forms user control for camera temperature viewing
///-----------------------------------------------------------------

using Flir.Atlas.Live;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Remote;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Flir.Atlas.Image;

namespace METEC
{
    public partial class FLIRCameraTemperatureControl : UserControl
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Camera instance
        private FLIRCamera _camera;
        private Timer _timer = new Timer();

        // Constructor
        public FLIRCameraTemperatureControl()
        {
            InitializeComponent();
        }

        // Initialize with camera instance
        public void Initialize(FLIRCamera camera)
        {
            _camera = camera;
            _camera.ConnectionStatusChanged += _camera_ConnectionStatusChanged;

            _timer.Tick += _timer_UpdateDisplay;
            _timer.Interval = 100;
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
                groupBoxTemperature.Enabled = true;
                groupBoxScale.Enabled = true;
                try
                {
                    UpdateTemperatureRanges();
                }
                catch (Exception exception)
                {
                    _logger.Warn("Temperature Control", String.Format("Setting temperature ranges failed - {0}", exception.Message));
                    groupBoxTemperature.Enabled = false;
                }
                try
                {
                    UpdateScale();
                }
                catch (Exception exception)
                {
                    _logger.Warn("Temperature Control", String.Format("Setting scale failed - {0}", exception.Message));
                    groupBoxScale.Enabled = false;
                }
            }
            else
            {
                groupBoxTemperature.Enabled = false;
                groupBoxScale.Enabled = false;
                //groupBoxManualScale.Enabled = false
            }
        }

        private void UpdateTemperatureRanges()
        {
            comboBoxTemperature.Items.Clear();

            var tempRanges = new List<Range<double>>(_camera.RemoteSettings.EnumerateTemperatureRanges());
            int index = _camera.RemoteSettings.GetTemperatureRangeIndex();

            tempRanges.ForEach(range => comboBoxTemperature.Items.Add(range));
            if (index >= 0)
            {
                comboBoxTemperature.SelectedItem = tempRanges[index];
            }
            else
            {
                _logger.Warn("Temperature Control", String.Format("Temperature range index '{0}' not valid! ({1})",
                    index, tempRanges));
            }
        }

        private void UpdateScale()
        {
            radioButtonAutoScale.Checked = _camera.RemoteSettings.GetScaleAdjustMode() == ScaleAdjustMode.Auto;
            groupBoxManualScale.Enabled = radioButtonManualScale.Checked;
            Console.WriteLine(radioButtonManualScale.Checked);

            var scale = _camera.RemoteSettings.GetScaleLimits();
            textBoxMinScale.Text = scale.Minimum.ToString();
            textBoxMaxScale.Text = scale.Maximum.ToString();
        }

        private void radioButtonScaleMode_CheckChanged(object sender, EventArgs e)
        {
            ScaleAdjustMode mode = ScaleAdjustMode.Auto;
            if (radioButtonManualScale.Checked)
            {
                mode = ScaleAdjustMode.Manual;
                groupBoxManualScale.Enabled = true;
            }
            else
                groupBoxManualScale.Enabled = false;

            _camera.RemoteSettings.SetScaleAdjustMode(mode);
        }

        private void buttonSetTemperatureRange_Click(object sender, EventArgs e)
        {
            _logger.Info("Temperature Control", String.Format("Camera {0} setting temperature range - {1}", _camera.Index, comboBoxTemperature.SelectedItem));
            _camera.RemoteSettings.SetTemperatureRangeIndex(comboBoxTemperature.SelectedIndex);
            // _camera_Updated = true;
        }

        private void buttonSetScale_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMinScale.Text, out double minTemp) && double.TryParse(textBoxMaxScale.Text, out double maxTemp))
            {
                if (0 < minTemp && minTemp < maxTemp && maxTemp < 5000.0)
                {
                    _logger.Info("Temperature Control", String.Format("Camera {0} setting scale: {1} K - {2} K ", _camera.Index, minTemp, maxTemp));
                    _camera.RemoteSettings.SetScaleLimits(new Range<double>(minTemp, maxTemp));
                    // _camera_Updated = true;
                }
                else
                    MessageBox.Show("Temperature Control", "Scale must be between 0-5000 K!");
            }
            else
            {
                MessageBox.Show("Temperature Control", "Invalid min/max scale!");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
    }
}

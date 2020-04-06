///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Windows form to change settings on FLIRCamera
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace METEC
{
    public partial class FLIRCameraSettingsForm : Form
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Private instane variables
        private FLIRCameraSettingsEventArgs _settings;

        // Constructors
        public FLIRCameraSettingsForm()
        {
            InitializeComponent();
        }

        public FLIRCameraSettingsForm(FLIRCameraSettingsEventArgs settings)
        {
            InitializeComponent();
            Initialize(settings);
        }

        public void Initialize(FLIRCameraSettingsEventArgs settings)
        {
            _settings = settings;
            this.Text = String.Format("Camera {0}", _settings.Index);

            
            if (!_settings.HighSensitivitySupported)
            {
                lowSensitivityButton.Checked = true;
                sensitivityGroup.Enabled = false;
            }
            else
                highSensitivityButton.Checked = _settings.HighSensitivity;

            SetFrameRates(settings.FrameRateList, _settings.SelectedFrameRate);
            SetResolutions(settings.ResolutionList, _settings.SelectedResolution);

            minTemperatureBox.Text = _settings.MinTemperature.ToString();
            maxTemperatureBox.Text = _settings.MaxTemperature.ToString();
        }

        // Setup frame rates in dropdown menu
        private void SetFrameRates(List<string> frameRates, string selectedFrameRate)
        {
            frameRates.ForEach(rate => frameRateMenu.Items.Add(rate));
            frameRateMenu.SelectedItem = selectedFrameRate;
        }

        // Setup resolutions in dropdown menu
        private void SetResolutions(List<Size> resolutions, Size selectedResolution)
        {
            resolutions.ForEach(res => resolutionMenu.Items.Add(res));
            resolutionMenu.SelectedItem = selectedResolution;
        }

        private bool _buttonExit = false;
        // Handler for cancel button press
        private void cancelButton_Click(object sender, EventArgs e)
        {
            _logger.Info("Settings Form", "User exit via cancel button");
            _buttonExit = true;
            Close();
        }

        // Event handler to apply settings to camera(s)
        public event EventHandler<FLIRCameraSettingsEventArgs> ApplySettingsEvent;
        private void applyButton_Click(object sender, EventArgs e)
        {
            _logger.Info("Settings Form", "User exit via apply button");
            _buttonExit = true;
            ApplySettings();
            Close();
        }

        // Raise apply settings event
        private void ApplySettings()
        {
            if (ApplySettingsEvent != null)
            {
                sensitivityGroup.Enabled = false;
                minTemperatureBox.Enabled = false;
                maxTemperatureBox.Enabled = false;
                frameRateMenu.Enabled = false;
                resolutionMenu.Enabled = false;
                applyButton.Enabled = false;
                cancelButton.Enabled = false;
                applyToAllBox.Enabled = false;

                this.Cursor = Cursors.WaitCursor;

                _settings.ApplyToAll = applyToAllBox.Checked;

                _settings.HighSensitivity = highSensitivityButton.Checked;
                _settings.SelectedFrameRate = frameRateMenu.SelectedItem.ToString();
                _settings.SelectedResolution = (Size)resolutionMenu.SelectedItem;

                ApplySettingsEvent(this, _settings);

                this.Cursor = Cursors.Default;
            }
            else
                _logger.Warn("Settings Form", "No handler for 'ApplySettingsEvent'!");
        }

        // Ask user whether to apply settings on exit
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_buttonExit)
            {
                _logger.Info("Settings Form", "Form closing via window exit");
                var result = MessageBox.Show("Apply settings?", "Settings", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Cancel:
                        _logger.Info("Settings Form", "Form closing canceled");
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        _logger.Info("Settings Form", "Applying settings to camera and closing");
                        ApplySettings();
                        break;
                    default:
                        _logger.Info("Settings Form", "Closing without applying settings");
                        break;
                }
            }
        }

        // Ensure valid minimum temperature
        private void minTemperatureBox_Leave(object sender, EventArgs e)
        {
            double tempFloat;
            if (!double.TryParse(minTemperatureBox.Text, out tempFloat) || tempFloat < 0)
            {
                _logger.Info("Settings Form", String.Format("Read invalid minimum temperature: '{0}'", minTemperatureBox.Text));
                MessageBox.Show("Temperature must be a positive number.", "Settings");
                minTemperatureBox.Text = _settings.MinTemperature.ToString();
            }
            else if (tempFloat > double.Parse(maxTemperatureBox.Text))
            {
                _logger.Info("Settings Form", String.Format("Read minimum temperature greater than maximum temperature: '{0}'", minTemperatureBox.Text));
                MessageBox.Show("Minimum temperature must be less than maximum temperature.", "Settings");
                minTemperatureBox.Text = _settings.MinTemperature.ToString();
            }
            else _settings.MinTemperature = tempFloat;
        }

        // Restrict minimum temperature to digits and one '.'
        private void minTemperatureBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains('.')))
            {
                e.Handled = true;
            }
        }

        // Ensure valid maximum temperature
        private void maxTemperatureBox_Leave(object sender, EventArgs e)
        {
            double tempFloat;
            if (!double.TryParse(minTemperatureBox.Text, out tempFloat) || tempFloat < 0)
            {
                _logger.Info("Settings Form", String.Format("Read invalid maximum temperature: '{0}'", maxTemperatureBox.Text));
                MessageBox.Show("Temperature must be a positive number.", "Settings");
                maxTemperatureBox.Text = _settings.MaxTemperature.ToString();
            }
            else if (tempFloat < double.Parse(minTemperatureBox.Text))
            {
                _logger.Info("Settings Form", String.Format("Read maximum temperature less than minimum temperature: '{0}'", maxTemperatureBox.Text));
                MessageBox.Show("Maximum temperature must be greater than minimum temperature.", "Settings");
                maxTemperatureBox.Text = _settings.MaxTemperature.ToString();
            }
            else _settings.MaxTemperature = tempFloat;
        }

        // Restrict maximum temperature to digits and one '.'
        private void maxTemperatureBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains('.')))
            {
                e.Handled = true;
            }
        }
    }
}

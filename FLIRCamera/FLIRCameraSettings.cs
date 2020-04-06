///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Class to manage settings on FLIRCamera
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Flir.Atlas.Image;
using Flir.Atlas.Live.Device;

namespace METEC
{
    public class FLIRCameraSettings
    {
        // Camera instance
        private Camera _camera;

        public FLIRCameraSettings(Camera camera, int index)
        {
            _camera = camera;
            Index = index;
        }

        public FLIRCameraSettingsEventArgs GetSettings()
        {
            var settings = new FLIRCameraSettingsEventArgs
            {
                Index = Index,
                ApplyToAll = false,
                MinTemperature = MinTemperature,
                MaxTemperature = MaxTemperature,
                FrameRateSupported = FrameRateSupported,
                FrameRateList = FrameRateList,
                SelectedFrameRate = SelectedFrameRate,
                ResolutionSupported = ResolutionSupported,
                ResolutionList = ResolutionList,
                SelectedResolution = SelectedResolution,
                HighSensitivitySupported = HighSensitivitySupported,
                HighSensitivity = HighSensitivity,
                ObjectDistance = ObjectDistance,
                TemperatureRange = TemperatureRange
            };
            return settings;
        }
        
        // METEC Camera settings
        public readonly int Index;
        public bool RecordingEnabled = true;

        public double MinTemperature { get; set; } = 0;
        public double MaxTemperature { get; set; } = 50;

        // Public settings accessors
        // Camera streaming settings
        public bool FrameRateSupported
        {
            get
            {
                return _camera.FrameRateIndex >= 0 && _camera.EnumerateFrameRates().Count > 0;
            }
        }

        public List<string> FrameRateList
        {
            get
            {
                if (FrameRateSupported)
                    return _camera.EnumerateFrameRates();
                else
                    return new List<string> { "N/A" };
            }
        }

        public string SelectedFrameRate
        {
            get
            {
                if (FrameRateSupported)
                    return _camera.EnumerateFrameRates()[_camera.FrameRateIndex];
                else
                    return "N/A";
            }
            set
            {
                List<String> frameRates = _camera.EnumerateFrameRates();
                if (frameRates.Contains(value))
                    _camera.FrameRateIndex = frameRates.FindIndex(rate => rate == value);

                else
                    throw new ArgumentOutOfRangeException("Set Frame Rate",
                        String.Format("Frame rate '{0}' not supported!.", value));
            }
        }

        public bool ResolutionSupported
        {
            get
            {
                return _camera.SelectedResolutionIndex >= 0 && _camera.EnumerateResolutions().Count > 0;
            }
        }

        public List<Size> ResolutionList
        {
            get
            {
                if (ResolutionSupported)
                    return _camera.EnumerateResolutions();
                else
                    return new List<Size> { SelectedResolution };
            }
        }

        public Size SelectedResolution
        {
            get
            {
                if (!ResolutionSupported)
                    return _camera.GetImage().Size;
                else
                    return _camera.EnumerateResolutions()[_camera.SelectedResolutionIndex];
            }
            set
            {
                List<Size> resolutions = _camera.EnumerateResolutions();
                if (resolutions.Contains(value))
                    _camera.SelectedResolutionIndex = resolutions.FindIndex(res => res == value);
                else if (resolutions.Count > 0)
                    throw new ArgumentOutOfRangeException("Set Resolution",
                        String.Format("Resolution '{0}' not supported!", value));
            }
        }

        // Camera remote settings
        private bool? _highSensitivitySupported = null;
        public bool HighSensitivitySupported
        {
            get
            {
                if (_highSensitivitySupported != null)
                    return (bool)_highSensitivitySupported;
                else
                {
                    _highSensitivitySupported = _camera.RemoteControl.CameraSettings.IsHighSensitivityModeSupported();
                    return (bool)_highSensitivitySupported;
                }
            }
        }

        private bool? _highSensitivity = null;
        public bool HighSensitivity
        {
            get
            {
                if (HighSensitivitySupported && _highSensitivity != null)
                    return (bool)_highSensitivity;
                else if (HighSensitivitySupported && _highSensitivity == null)
                {
                    _highSensitivity = _camera.RemoteControl.CameraSettings.IsHighSensitivityModeEnabled();
                    return (bool)_highSensitivity;
                }
                else
                    return false;
            }
            set
            {
                if (HighSensitivitySupported)
                {
                    _camera.RemoteControl.CameraSettings.SetHighSensitivityModeEnabled(value);
                    _highSensitivity = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Set High Sensitivity Mode",
                        String.Format("High sensitivity mode not supported!"));
            }
        }

        public double ObjectDistance
        {
            get
            {
                return _camera.RemoteControl.CameraSettings.GetObjectDistance();
            }
            set
            {
                if (0 < value && value < 10000.0)
                {
                    _camera.RemoteControl.CameraSettings.SetObjectDistance(value);
                }
                else
                    throw new ArgumentOutOfRangeException("Set Object Distance",
                        String.Format("Object distance '{0}' not supported!", value));
            }
        }

        public Range<double> TemperatureRange
        {
            get
            {
                var ranges = _camera.RemoteControl.CameraSettings.EnumerateTemperatureRanges();
                if (ranges.Any())
                {
                    var index = _camera.RemoteControl.CameraSettings.GetTemperatureRangeIndex();
                    return ranges[index];
                }
                else
                    return null;
            }
            set
            {
                var ranges = new List<Range<double>>(_camera.RemoteControl.CameraSettings.EnumerateTemperatureRanges());
                Console.WriteLine(value.ToString());
                foreach (var r in ranges) Console.WriteLine(r.ToString());
                if (ranges.Contains(value))
                {
                    var index = ranges.FindIndex(range => range == value);
                    _camera.RemoteControl.CameraSettings.SetTemperatureRangeIndex(index);
                }
                else
                    throw new ArgumentOutOfRangeException("Set Temperature Range",
                        String.Format("Temperature range '{0}' not supported!", value));
            }
        }

        public new string ToString()
        {
            string settings = "";
            settings += String.Format("Camera index: {0}\r\n", Index);
            settings += String.Format("Minimum viewing temperature: {0}\r\n", MinTemperature);
            settings += String.Format("Maximum viewing temperature: {0}\r\n", MaxTemperature);
            settings += String.Format("Frame rates supported: {0}\r\n", FrameRateSupported);
            if (FrameRateSupported)
                settings += String.Format("Current frame rate: {0}\r\n", SelectedFrameRate);
            settings += String.Format("Resolutions supported: {0}\r\n", FrameRateSupported);
            settings += String.Format("Current resolution: {0}\r\n", SelectedResolution);
            settings += String.Format("High sensitivity mode supported: {0}\r\n", HighSensitivitySupported);
            if (HighSensitivitySupported)
                settings += String.Format("High sensitivity mode enabled: {0}\r\n", HighSensitivity);
            settings += String.Format("Current object distance: {0}\r\n", ObjectDistance);
            settings += String.Format("Current temperature range: {0}\r\n", TemperatureRange);

            return settings;
        }
    }
}

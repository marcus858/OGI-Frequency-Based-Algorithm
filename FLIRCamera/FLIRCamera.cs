///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Wrapper class around FLIR thermal camera
///-----------------------------------------------------------------

using System;
using Flir.Atlas.Live;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;
using Flir.Atlas.Image;
using Flir.Atlas.Live.Recorder;
using Flir.Atlas.Live.Remote;

namespace METEC
{
    public class FLIRCamera
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Camera instance
        private Camera _camera;

        // Public camera control accessors
        public Recorder Recorder;
        public RemoteCameraFocus Focus;
        public RemoteCameraSettings RemoteSettings;
        public RemoteCameraGeoLocation GeoLocation;

        // Camera settings
        public readonly int Index;
        public FLIRCameraSettings Settings;

        // Constructors
        public FLIRCamera(int index = 0) { Index = index; }
        public FLIRCamera(CameraDeviceInfo cameraDeviceInfo, int index = 0)
        {
            ConnectCamera(cameraDeviceInfo);
            Index = index;
        }

        // Camera status properties
        public bool NewImage { get; private set; } = false;
        public bool RecordingEnabled { get; set; } = true;
        public ConnectionStatus CameraConnectionStatus
        {
            get
            {
                try
                {
                    return _camera.ConnectionStatus;
                }
                catch (NullReferenceException)
                {
                    return ConnectionStatus.Disconnected;
                }
            }
        }
        public FLIRCameraStatus CameraStatus
        {
            get
            {
                if (CameraConnectionStatus != ConnectionStatus.Connected)
                    return new FLIRCameraStatus(Index, CameraConnectionStatus);
                else
                    return new FLIRCameraStatus(Index, CameraConnectionStatus, _camera.CameraDeviceInfo.Name, CameraGrabbing, Settings.HighSensitivity,
                        Settings.MinTemperature, Settings.MaxTemperature, Settings.SelectedFrameRate, Settings.SelectedResolution);
            }
        }
        public bool CameraGrabbing { get { return _camera.IsGrabbing; } }

        // Connect/disconnect camera
        public void ConnectCamera(CameraDeviceInfo cameraDeviceInfo)
        {
            _logger.Debug("METEC Camera", String.Format("Camera connection info - {0}", cameraDeviceInfo));
            DisposeCamera();
            switch (cameraDeviceInfo.SelectedStreamingFormat)
            {
                case ImageFormat.FlirFileFormat:
                    _camera = new ThermalCamera();
                    break;
                case ImageFormat.Argb:
                    _camera = new VideoOverlayCamera();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _camera.ConnectionStatusChanged += _camera_ConnectionStatusChanged;
            _camera.GetImage().Changed += _camera_NewImage;
            _camera.DeviceError += _camera_DeviceError;
            _camera.Connect(cameraDeviceInfo);

            Recorder = _camera.Recorder;
            Focus = _camera.RemoteControl.Focus;
            RemoteSettings = _camera.RemoteControl.CameraSettings;
            GeoLocation = _camera.RemoteControl.GeographicLocation;

            Settings = new FLIRCameraSettings(_camera, Index);
        }

        public void DisconnectCamera()
        {
            if (_camera == null)
                return;
            _camera.Disconnect();
        }

        public void DisposeCamera()
        {
            if (_camera == null)
                return;
            Recorder = null;
            _camera.ConnectionStatusChanged -= _camera_ConnectionStatusChanged;
            _camera.GetImage().Changed -= _camera_NewImage;
            _camera.DeviceError -= _camera_DeviceError;
            _camera.Dispose();
        }

        // Camera event handlers
        public event EventHandler<ImageChangedEventArgs> ImageChanged;
        private void _camera_NewImage(object sender, ImageChangedEventArgs e)
        {
            NewImage = true;
            if (ImageChanged != null)
                ImageChanged(this, e);
        }

        public event EventHandler<ConnectionStatusChangedEventArgs> ConnectionStatusChanged;
        private void _camera_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs e)
        {
            _logger.Debug("METEC Camera", String.Format("Camera {0} connection status changed - {1}", Index, e.Status));

            if (ConnectionStatusChanged != null)
                ConnectionStatusChanged(this, e);
        }

        public event EventHandler<DeviceErrorEventArgs> DeviceError;
        private void _camera_DeviceError(object sender, DeviceErrorEventArgs e)
        {
            if (DeviceError != null)
                DeviceError(this, e);
        }

        // Camera accessor methods
        public ImageBase GetImage()
        {
            NewImage = false;
            return _camera.GetImage();
        }

        public bool StartGrabbing() { return _camera.StartGrabbing(); }
        public void StopGrabbing() { _camera.StopGrabbing(); }

        public GPSInfo GetGpsInfo() { return _camera.RemoteControl.GeographicLocation.GetGpsInfo(); }
        public CompassInfo GetCompassInfo() { return _camera.RemoteControl.GeographicLocation.GetCompassInfo(); }

        // Change camera settings
        public void ChangeSettings(FLIRCameraSettingsEventArgs newSettings)
        {
            _changeSettings(Settings.GetSettings(), newSettings);
        }


        public void ChangeSettings(FLIRCameraSettingsEventArgs oldSettings, FLIRCameraSettingsEventArgs newSettings)
        {
            _changeSettings(oldSettings, newSettings);
        }

        private void _changeSettings(FLIRCameraSettingsEventArgs oldSettings, FLIRCameraSettingsEventArgs newSettings)
        {
            if (newSettings.MinTemperature != oldSettings.MinTemperature)
                Settings.MinTemperature = newSettings.MinTemperature;
            if (newSettings.MaxTemperature != oldSettings.MaxTemperature)
                Settings.MaxTemperature = newSettings.MaxTemperature;
            if (newSettings.SelectedFrameRate != oldSettings.SelectedFrameRate && Settings.FrameRateSupported)
                Settings.SelectedFrameRate = newSettings.SelectedFrameRate;
            if (newSettings.SelectedResolution != oldSettings.SelectedResolution && Settings.ResolutionSupported)
            {
                Console.WriteLine("METEC Camera Setting resolution");
                Settings.SelectedResolution = newSettings.SelectedResolution;
            }
            if (newSettings.HighSensitivity != oldSettings.HighSensitivity && Settings.HighSensitivitySupported)
                Settings.HighSensitivity = newSettings.HighSensitivity;
            if (newSettings.ObjectDistance != oldSettings.ObjectDistance)
                Settings.ObjectDistance = newSettings.ObjectDistance;
            if (newSettings.TemperatureRange.Minimum != oldSettings.TemperatureRange.Minimum || newSettings.TemperatureRange.Maximum != oldSettings.TemperatureRange.Maximum)
                Settings.TemperatureRange = newSettings.TemperatureRange;

            _logger.Info("METEC Camera", String.Format("New settings applied to camera {0}:\r\n{1}", Index, newSettings.ToString()));
        }
    }
}

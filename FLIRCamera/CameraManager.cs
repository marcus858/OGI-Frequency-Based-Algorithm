///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Manager for multiple FLIRCamera instances
///-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Flir.Atlas.Image;
using Flir.Atlas.Live.Discovery;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Remote;

namespace METEC
{
    public class CameraManager : IEnumerable<FLIRCamera>
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Camera instance variables
        private SortedDictionary<int, FLIRCamera> _cameras;

        public SortedDictionary<int, FLIRCameraStatus> CameraStatus
        {
            get
            {
                var status = new SortedDictionary<int, FLIRCameraStatus>();
                foreach (var camera in _cameras)
                    status.Add(camera.Key, camera.Value.CameraStatus);
                return status;
            }
        }

        public int NumCameras { get { return _cameras.Count; } }

        // Constructors
        public CameraManager() { _cameras = new SortedDictionary<int, FLIRCamera>();  }

        // Make class enumerable
        public IEnumerator<FLIRCamera> GetEnumerator()
        {
            foreach (var camera in _cameras)
                yield return camera.Value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(int index)
        {
            return _cameras.ContainsKey(index);
        }

        // Connect to camera
        public void ConnectCamera(CameraDeviceInfo cameraDeviceInfo, int index)
        {
            _cameras.Add(index, new FLIRCamera(cameraDeviceInfo, index));
            _cameras[index].ImageChanged += _camera_ImageChanged;
            _cameras[index].ConnectionStatusChanged += _camera_ConnectionStatusChanged;
            _cameras[index].DeviceError += _camera_DeviceError;
            _logger.Info("Camera Manager", String.Format("Connecting to camera: {0}", index));
        }

        // Async disconnect from camera
        public void DisconnectCamera(int index)
        {
            _cameras[index].DisconnectCamera();
            _logger.Info("Camera Manager", String.Format("Disconnected from camera: {0}", index));
        }

        // Async disconnect from all cameras
        public void Disconnect()
        {
            foreach(var camera in _cameras)
            {
                camera.Value.DisconnectCamera();
                _logger.Info("Camera Manager", String.Format("Disconnected from camera: {0}", camera.Key));
            }
        }

        // Dispose camera
        public void DisposeCamera(int index)
        {
            _cameras[index].ImageChanged -= _camera_ImageChanged;
            _cameras[index].ConnectionStatusChanged -= ConnectionStatusChanged;
            _cameras[index].DeviceError -= _camera_DeviceError;
            _cameras[index].DisposeCamera();
            _cameras.Remove(index);
            _logger.Info("Camera Manager", String.Format("Disposed camera: {0}", index));
        }

        // Dispose all cameras
        public void Dispose()
        {
            foreach (var camera in _cameras)
            {
                camera.Value.ImageChanged -= ImageChanged;
                camera.Value.ConnectionStatusChanged -= ConnectionStatusChanged;
                camera.Value.DeviceError -= DeviceError;
                camera.Value.DisposeCamera();
                _logger.Info("Camera Manager", String.Format("Disposed camera: {0}", camera.Key));
            }
            _cameras.Clear();
        }

        // Apply settings from user
        public event EventHandler<FLIRCameraSettingsEventArgs> SettingsChanged;
        public void ApplySettings(object sender, FLIRCameraSettingsEventArgs settings)
        {
            if (settings.ApplyToAll)
            {
                _logger.Info("Camera Manager", "Applying settings to all cameras");
                _cameras.Values.ToList().ForEach(camera => camera.ChangeSettings(settings));
            }
            else
            {
                _logger.Info("Camera Manager", String.Format("Applying settings to camera: {0}", settings.Index));
                _cameras[settings.Index].ChangeSettings(settings);
            }

            if (SettingsChanged != null)
                SettingsChanged(this, settings);
        }

        // Camera settings getter/setters
        public FLIRCamera Camera(int index) { return _cameras[index]; }
        public FLIRCameraStatus GetCameraStatus(int index) { return _cameras[index].CameraStatus; }

        public bool GetSensitivity(int index) { return _cameras[index].Settings.HighSensitivity; }
        public void SetHighSensitivity(int index) { _cameras[index].Settings.HighSensitivity = true; }
        public void SetLowSensitivity(int index) { _cameras[index].Settings.HighSensitivity = false; }

        public double GetMinTemperature(int index) { return _cameras[index].Settings.MinTemperature; }
        public void SetMinTemperature(int index, double temp) { _cameras[index].Settings.MinTemperature = temp; }

        public double GetMaxTemperature(int index) { return _cameras[index].Settings.MaxTemperature; }
        public void SetMaxTemperature(int index, double temp) { _cameras[index].Settings.MaxTemperature = temp; }

        public string GetFrameRate(int index) { return _cameras[index].Settings.SelectedFrameRate; }
        public void SetFrameRate(int index, string frameRate) { _cameras[index].Settings.SelectedFrameRate = frameRate; }

        public Size GetResolution(int index) { return _cameras[index].Settings.SelectedResolution; }
        public void SetResolution(int index, Size resolution) { _cameras[index].Settings.SelectedResolution = resolution; }

        public GPSInfo GetGpsInfo(int index) { return _cameras[index].GetGpsInfo(); }
        public CompassInfo GetCompassInfo(int index) { return _cameras[index].GetCompassInfo(); }

        public bool NewImage(int index) { return _cameras[index].NewImage; }
        public ConnectionStatus CameraConnectionStatus(int index) { return _cameras[index].CameraConnectionStatus; }
        public bool CameraGrabbing(int index) { return _cameras[index].CameraGrabbing; }

        public Flir.Atlas.Live.Recorder.Recorder Recorder(int index) { return _cameras[index].Recorder; } 
        public RemoteCameraFocus Focus(int index) { return _cameras[index].Focus; }
        public FLIRCameraSettingsEventArgs Settings(int index) { return _cameras[index].Settings.GetSettings(); }

        // Event handler for new image on any camera
        public event EventHandler<Flir.Atlas.Image.ImageChangedEventArgs> ImageChanged;
        private void _camera_ImageChanged(object sender, ImageChangedEventArgs e)
        {
            if (ImageChanged != null)
                ImageChanged(sender, e);
        }

        // Event handler for connection status changed on any camera
        public event EventHandler<Flir.Atlas.Live.ConnectionStatusChangedEventArgs> ConnectionStatusChanged;
        private void _camera_ConnectionStatusChanged(object sender, Flir.Atlas.Live.ConnectionStatusChangedEventArgs e)
        {
            if (ConnectionStatusChanged != null)
                ConnectionStatusChanged(sender, e);
        }

        // Event handler for camera device error on any camera
        public event EventHandler<Flir.Atlas.Live.Device.DeviceErrorEventArgs> DeviceError;
        private void _camera_DeviceError(object sender, Flir.Atlas.Live.Device.DeviceErrorEventArgs e)
        {
            if (DeviceError != null)
                DeviceError(sender, e);
        }

        // Retrieve latest image from camera at index
        public ImageBase GetImage(int index)
        {
            return _cameras[index].GetImage();
        }

        // Start grabbing images from camera at index
        public bool StartGrabbing(int index)
        {
            _logger.Info("Camera Manager", String.Format("Starting grabbing images on camera: {0}", index));
            return _cameras[index].StartGrabbing();
        }

        // Stop grabbing images from camera at index
        public void StopGrabbing(int index)
        {
            _logger.Info("Camera Manager", String.Format("Stopping grabbing images on camera: {0}", index));
            _cameras[index].StopGrabbing();
        }
    }
}

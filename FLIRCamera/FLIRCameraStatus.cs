///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: FLIRCamera status information
///-----------------------------------------------------------------

using System.Drawing;
using Flir.Atlas.Live.Device;

namespace METEC
{
    public class FLIRCameraStatus
    {
        public int Index { get; private set; }
        public ConnectionStatus CameraConnectionStatus { get; private set; }
        public string Name { get; private set; }
        public bool CameraGrabbing { get; private set; }
        public bool HighSensitivity { get; private set; }
        public double MinTemperature { get; private set; }
        public double MaxTemperature { get; private set; }
        public string FrameRate { get; private set; }
        public Size Resolution { get; private set; }

        public FLIRCameraStatus(int index, ConnectionStatus status)
        {
            Index = index;
            CameraConnectionStatus = status;
        }

        public FLIRCameraStatus(int index, ConnectionStatus status, string name, bool grabbing, bool highSensitivity,
            double minTemperature, double maxTemperature, string frameRate, Size resolution)
        {
            Index = index;
            CameraConnectionStatus = status;
            Name = name;
            CameraGrabbing = grabbing;
            HighSensitivity = highSensitivity;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            FrameRate = frameRate;
            Resolution = resolution;
        }
    }
}

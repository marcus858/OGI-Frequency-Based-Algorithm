///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: FLIRCamera settings values
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using Flir.Atlas.Image;

namespace METEC
{
    // Event arguments for METEC camera settings
    public class FLIRCameraSettingsEventArgs : EventArgs
    {
        // METEC Camera indexing
        public int Index { get; set; }
        public bool ApplyToAll { get; set; }

        // Viewing settings
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }

        // Streaming settings
        public bool FrameRateSupported { get; set; }
        public List<string> FrameRateList { get; set; }
        public string SelectedFrameRate { get; set; }
        public bool ResolutionSupported { get; set; }
        public List<Size> ResolutionList { get; set; }
        public Size SelectedResolution { get; set; }

        // Remote control settings
        public bool HighSensitivitySupported { get; set; }
        public bool HighSensitivity { get; set; }
        public double ObjectDistance { get; set; }
        public Range<Double> TemperatureRange { get; set; }

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

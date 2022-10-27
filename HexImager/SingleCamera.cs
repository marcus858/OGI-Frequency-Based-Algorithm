using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;
using Flir.Atlas.Image;
using Flir.Atlas.Image.Palettes;
using Flir.Atlas.Image.ImageProcessing;
using Flir.Atlas.Live.Remote;
using System.Drawing.Drawing2D;

using System.IO;
using System.Collections;
using Flir.Atlas.Image.Alarms;
using Flir.Atlas.Image.Fusion;
using Flir.Atlas.Image.Isotherms;
using Flir.Atlas.Image.Measurements;
using Appearance = Flir.Atlas.Image.Isotherms.Appearance;



namespace METEC
{
    public partial class SingleCamera : Form
    {
        private CameraManager _manager;
        private readonly int _index;
        public Timer _updateTime = new Timer();
        private ThermalImageFile _image;

        public SingleCamera(CameraManager manager, int index)
        {
            InitializeComponent();
           
            _manager = manager;
            _index = index;

            flirCameraFocusControlForm1.Initialize(_manager.Camera(index));
            //metecCameraTemperatureControl1.Initialize(_manager.Camera(index));
            //rangeSliderControl1.Initialize();

            _updateTime.Tick += UpdateFeed;
            _updateTime.Interval = 20;
            _updateTime.Start();
        }

        private bool IsDirty { get; set; }

        private const string FileFilter = "IR Image Files(*.jpg;*.img;*.seq;*.fcf)|*.jpg;*.img;*.seq;*.fcf|All files (*.*)|*.*";


        private void UpdateFeed(object sender, EventArgs e)
        {
            if (_manager.Contains(_index))
            {
                _manager.GetImage(_index).EnterLock();
                try
                {
                    // CameraFeed1.Image = _manager.GetImage(index).Image; 
                    SingleCamFeed.Image = _manager.GetImage(_index).Image;
                }
                catch (Exception exception)
                {
                    Trace.TraceError(exception.Message);
                }
                finally
                {
                    _manager.GetImage(_index).ExitLock();
                }
            }
        }
        private void UpdateScale()
        {
            var bmp = new Bitmap(pictureBoxScale.ClientSize.Width, pictureBoxScale.ClientSize.Height);
            var scaleImage = _image.Scale.Image;
            using (var g = Graphics.FromImage(bmp))
            {
                //Use gdi+ to interpolate with nearest neighbor
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(scaleImage, 0, 0, bmp.Width * 2, bmp.Height);
            }
            pictureBoxScale.Image = bmp;

            labelMax.Text = _image.Scale.Range.Maximum.ToString("F02");
            labelMin.Text = _image.Scale.Range.Minimum.ToString("F02");
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_manager == null || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString())) return;
            var thImg = _manager.GetImage(_index) as ThermalImage;
            if (thImg == null) return;
            thImg.Palette = PaletteManager.FromString(comboBox1.SelectedItem.ToString());
            IsDirty = true;
        }

        private void SingleCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_updateTime != null)
                _updateTime.Stop();
            if (_manager != null)
            {
                _manager.Disconnect();
                _manager.Dispose();
            }
        }
        public void SingleCamera_Load(object sender, EventArgs e)
        {
           
        }
        private void cameraSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLIRCameraSettingsForm settings = new FLIRCameraSettingsForm(_manager.Settings(_index));
            settings.ApplySettingsEvent += _manager.ApplySettings;
            settings.Show();
            settings.Focus();

        }
    }
}

    





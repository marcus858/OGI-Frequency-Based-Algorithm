using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flir.Atlas.Image;
using Flir.Atlas.Image.Playback;
using Flir.Atlas.Image.WinForms;

namespace METEC
{
    public partial class HexImagerViewerForm : Form
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // private SortedDictionary<int, ThermalImageFile> _images;
        private string FlirDirectory;
        private HexImagerFile _imageFile;

        private readonly Timer _timer = new Timer();

        public HexImagerViewerForm()
        {
            InitializeComponent();
            FlirDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests\";
        }

        public HexImagerViewerForm(HexImagerFile recording)
        {
            InitializeComponent();

            FlirDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests\";
            Initialize(recording);
        }

        private void Initialize(HexImagerFile imageFile)
        {
            if (_imageFile != null)
                _imageFile.Clear();

            _imageFile = imageFile;
            _imageFile.FileOpen = true;

            foreach (var flirFile in _imageFile)
            {
                // var image = new ThermalImageFile(infoList.Value.FullName);
                // Images.Add(infoList.Key, image);

                _logger.Info("Viewer Form", String.Format("Initializing sequence from camera {0}", flirFile.Index));
                flirFile.Changed += ChangeImage;

                // image.Changed += (sender, e) => ChangeImage(image, infoList.Key);
                ChangeImage(flirFile, null);
                Console.WriteLine(String.Format("Sequence {0} has {1} frames, {2} duration at {3} FPS", flirFile.Index, flirFile.ImageFile.ThermalSequencePlayer.Count(), flirFile.ImageFile.ThermalSequencePlayer.Duration, flirFile.ImageFile.ThermalSequencePlayer.FrameRate));
            }

            playbackGroupBox.Enabled = _imageFile.FrameCount > 1;
            selectedIndexBar.Enabled = _imageFile.FrameCount > 1;
            selectedIndexBar.Maximum = _imageFile.FrameCount+10;

            exportButton.Enabled = true;

            _timer.Interval = 20;
            _timer.Tick += selectedIndexBar_UpdateValue;
            _timer.Start();
        }

        private HexImagerFile UnInitialize()
        {
            if (_imageFile == null)
                return null;

            _timer.Stop();
            _timer.Tick -= selectedIndexBar_UpdateValue;

            exportButton.Enabled = false;
            selectedIndexBar.Enabled = false;
            playbackGroupBox.Enabled = false;

            foreach (var flirFile in _imageFile)
            {
                _logger.Info("Viewer Form", String.Format("Unitializing sequence from camera {0}", flirFile.Index));
                flirFile.Changed -= ChangeImage;

                try
                {
                    (pictureBoxTable.Controls[flirFile.Index] as PictureBox).Image = null;
                }
                catch (Exception exception)
                {
                    _logger.Error("Viewer Form", exception.Message);
                }
            }

            var temp = _imageFile;
            _imageFile = null;

            return temp;
        }

        private void ChangeImage(object sender, ImageChangedEventArgs e)
        {
            var image = sender as FLIRImagerFile;
            // Console.WriteLine(String.Format("Viewer form changed image {0}", image.Index));
            image.ImageFile.EnterLock();
            try
            {
                (pictureBoxTable.Controls[image.Index] as PictureBox).Image = image.ImageFile.Image;
            }
            catch (Exception exception)
            {
                _logger.Error("Viewer Form", exception.Message);
            }
            finally
            {
                image.ImageFile.ExitLock();
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            _imageFile.Previous();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (_imageFile.PlayerStatus == ThermalSequencePlayer.PlayerStatus.Paused || _imageFile.PlayerStatus == ThermalSequencePlayer.PlayerStatus.Stopped)
            {
                previousButton.Enabled = false;
                nextButton.Enabled = false;
                stopButton.Enabled = true;
                playButton.Text = "Pause";

                _imageFile.Play();
            }
            else
            {
                previousButton.Enabled = true;
                nextButton.Enabled = true;
                playButton.Text = "Play";

                _imageFile.Pause();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            previousButton.Enabled = false;
            nextButton.Enabled = false;
            stopButton.Enabled = false;
            playButton.Text = "Play";

            if (_imageFile != null)
            {
                _imageFile.Stop();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _imageFile.Next();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FlirDirectory = dialog.SelectedPath;
            }
        }

        HexImagerFileSelectForm _selectForm;
        private void selectButton_Click(object sender, EventArgs e)
        {
            _selectForm = new HexImagerFileSelectForm(FlirDirectory);

            _selectForm.SelectedFileMouseDoubleClick += FileSelectedEventHandler;
            _selectForm.Show();
            _selectForm.Focus();
        }

        private void FileSelectedEventHandler(object sender, HexImagerFileSelectedEventArgs recording)
        {
            Initialize(recording.Recordings[0]);
            _selectForm.Close();

            var hist = _imageFile[0].ImageFile.Histogram;
            hist.Calculate();
        }

        private void METECViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= selectedIndexBar_UpdateValue;
            if (_imageFile != null)
            {
                _imageFile.Stop();

                foreach (var flirFile in _imageFile)
                {
                    flirFile.Changed -= ChangeImage;
                }
                _imageFile.Clear();
            }
        }

        private bool selectedIndexBar_UserControl = false;
        private void selectedIndexBar_UpdateValue(object sender, EventArgs e)
        {
            // pictureBox1.Image = _imageFile[1].ImageFile.Scale.Image;
            if (!selectedIndexBar_UserControl && _imageFile != null)
            {
                selectedIndexBar.Value = _imageFile.Values.First().ImageFile.ThermalSequencePlayer.SelectedIndex;
            }
        }

        private void selectedIndexBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (_imageFile.PlayerStatus == ThermalSequencePlayer.PlayerStatus.Playing)
            {
                selectedIndexBar_UserControl = true;
                _imageFile.Pause();
            }
        }

        private void selectedIndexBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedIndexBar_UserControl)
            {
                _imageFile.Play();
                selectedIndexBar_UserControl = false;
            }
            else
            {
                foreach (var flirFile in _imageFile)
                    ChangeImage(flirFile, null);
            }
        }

        private void selectedIndexBar_ValueChanged(object sender, EventArgs e)
        {
            _imageFile.SelectedIndex = selectedIndexBar.Value;
        }

        private void setTempButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(minTempTextBox.Text, out double minTemp) && double.TryParse(maxTempTextBox.Text, out double maxTemp))
            {
                foreach (var image in _imageFile)
                {
                    try
                    {
                        image.ImageFile.Scale.Range = new Range<double>(minTemp, maxTemp);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(String.Format("Exception setting camera {0} temperature: {1}", image.Index, exception.Message));
                    }
                }
            }
        }

        HexImagerExportForm _export;
        private void exportButton_Click(object sender, EventArgs e)
        {
            // var imageFile = UnInitialize();

            _export = new HexImagerExportForm(new List<HexImagerFile> { _imageFile });

            _export.Show();
            _export.Focus();
        }
    }
}

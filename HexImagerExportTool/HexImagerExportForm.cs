using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METEC
{
    public partial class HexImagerExportForm : Form
    {
        private List<HexImagerFile> _imageFiles;
        public string FlirDirectory;

        private Task exportTask;
        private int exportingIndex;
        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public HexImagerExportForm()
        {
            InitializeComponent();

            FlirDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests";
            outputPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests";
        }

        public HexImagerExportForm(List<HexImagerFile> imageFiles)
        {
            InitializeComponent();

            FlirDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests";
            outputPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests";

            Initialize(imageFiles);
        }

        public void Initialize(List<HexImagerFile> imageFiles)
        {
            _imageFiles = imageFiles;

            if (_imageFiles.Count < 2)
            {
                _imageFiles[0].FileOpen = true;
                recordingTextBox.Text = imageFiles[0].Timestamp.ToString();
            }
            else
            {
                recordingTextBox.Text = "";
                foreach (var imageFile in _imageFiles)
                {
                    imageFile.FileOpen = true;
                    recordingTextBox.Text += imageFile.Timestamp.ToString() + "; ";
                }
            }

            exportFormatComboBox.Items.Clear();

            if (imageFiles[0].FrameCount > 1)
                exportFormatComboBox.Items.Add("Avi");

            exportFormatComboBox.Items.Add(ImageFormat.Bmp);
            exportFormatComboBox.Items.Add(ImageFormat.Emf);
            exportFormatComboBox.Items.Add(ImageFormat.Exif);
            exportFormatComboBox.Items.Add(ImageFormat.Gif);
            exportFormatComboBox.Items.Add(ImageFormat.Icon);
            exportFormatComboBox.Items.Add(ImageFormat.Jpeg);
            exportFormatComboBox.Items.Add(ImageFormat.Png);
            exportFormatComboBox.Items.Add(ImageFormat.Tiff);
            exportFormatComboBox.Items.Add(ImageFormat.Wmf);
            exportFormatComboBox.Items.Add("CSV");
            exportFormatComboBox.SelectedIndex = 0;

            _timer.Interval = 100;
            _timer.Tick += UpdateGUI;
            _timer.Start();
        }

        private void browseOutputPathButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                outputPathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private CancellationTokenSource tokenSource;
        private void exportButton_Click(object sender, EventArgs e)
        {
            /*
            if (_imageFile == null)
            {
                MessageBox.Show("Hex Imager Export Tool", "No recording selected.");
                return;
            }
            else if (! new DirectoryInfo(outputPathTextBox.Text).Exists)
            {
                MessageBox.Show("Hex Imager Export Tool", "Invalid export directory.");
                return;
            }
            */
            exportButton.Enabled = false;
            tokenSource = new CancellationTokenSource();
            exportingIndex = 0;

            var format = exportFormatComboBox.SelectedItem;
            bool stitch = stitchCheckBox.Checked;

            if (format is ImageFormat)
                exportTask = Task.Run(() => ExportAsImage(outputPathTextBox.Text, format as ImageFormat, stitch), tokenSource.Token);
            else if (string.Compare(format.ToString(), "CSV") == 0)
                exportTask = Task.Run(() => ExportAsCSV(outputPathTextBox.Text), tokenSource.Token);
            else
                exportTask = Task.Run(() => ExportAsVideo(outputPathTextBox.Text, stitch), tokenSource.Token);
        }

        private void ExportAsVideo(string path, bool stitch)
        {
            for ( ; exportingIndex < _imageFiles.Count; exportingIndex++)
            {
                _imageFiles[exportingIndex].ExportAsVideo(path, stitch);
            }
            tokenSource = null;
        }

        private void ExportAsImage(string path, ImageFormat format, bool stitch)
        {
            for (; exportingIndex < _imageFiles.Count; exportingIndex++)
            {
                _imageFiles[exportingIndex].ExportAsImage(path, format, stitch);
            }
            tokenSource = null;
        }

        private void ExportAsCSV(string path)
        {
            for (; exportingIndex < _imageFiles.Count; exportingIndex++)
            {
                _imageFiles[exportingIndex].ExportAsCSV(path);
            }
            tokenSource = null;
        }

        private void UpdateGUI(object sender, EventArgs e)
        {
            if (_imageFiles != null && exportTask != null)
            {
                if (exportTask.Status == TaskStatus.Running && _imageFiles[exportingIndex].ExportTotalCount > 0)
                {
                    progressBar.Value = (int)(100 * _imageFiles[exportingIndex].ExportCompleteCount/ _imageFiles[exportingIndex].ExportTotalCount);
                    progressTextBox.Text = String.Format("Exporting {0} out of {1}", exportingIndex + 1, _imageFiles.Count);
                }
                else if (exportTask.Status == TaskStatus.RanToCompletion)
                {
                    progressBar.Value = 100;
                    exportButton.Enabled = true;
                    exportTask = null;
                }
            }
        }

        HexImagerFileSelectForm _selectForm;
        private void selectRecordingButton_Click(object sender, EventArgs e)
        {
            _selectForm = new HexImagerFileSelectForm(FlirDirectory);

            _selectForm.SelectedFileMouseDoubleClick += FileSelectedEventHandler;
            _selectForm.Show();
            _selectForm.Focus();
        }

        private void FileSelectedEventHandler(object sender, HexImagerFileSelectedEventArgs recording)
        {
            Initialize(recording.Recordings);
            _selectForm.Close();
        }

        private void browseRecordingButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                recordingTextBox.Clear();
                FlirDirectory = dialog.SelectedPath;
                _imageFiles = null;
            }
        }

        private void HexImagerExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tokenSource != null)
            {
                var status = MessageBox.Show("Warning: Closing this window will halt export. Stop exporting?",
                    "Hex Imager Export Tool", MessageBoxButtons.YesNo);
                if (status == DialogResult.Yes)
                {
                    tokenSource.Cancel();
                    _timer.Stop();
                }
                else
                    e.Cancel = true;
            }
        }
    }
}

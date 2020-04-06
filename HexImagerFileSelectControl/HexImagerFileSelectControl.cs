using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METEC
{
    public partial class HexImagerFileSelectControl : UserControl
    {
        private HexImagerFilesystem _filesystem;

        public HexImagerFileSelectControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            Initialize(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\");
        }

        public void Initialize(string path)
        {
            pathLabel.Text = path;
            _filesystem = new HexImagerFilesystem(pathLabel.Text);

            UpdateListView();
        }

        public void UpdateListView()
        {
            Console.WriteLine("Updating list view");
            recordingsListView.Items.Clear();

            var directoryMap = _filesystem.MapFilenames();

            foreach (var recording in directoryMap)
            {
                var lv = new ListViewItem(recording.FormatItem()) { Tag = recording };
                recordingsListView.Items.Add(lv);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathLabel.Text = dialog.SelectedPath;
                _filesystem.Path = dialog.SelectedPath;
            }
            UpdateListView();
        }

        // Recording viewer event delegate
        public event EventHandler<HexImagerFileSelectedEventArgs> SelectedFileMouseDoubleClick;
        private void recordingsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var items = recordingsListView.SelectedItems;
            if (items.Count > 0)
            {
                var recordings = new List<HexImagerFile>();
                foreach (ListViewItem item in items)
                {
                    recordings.Add((HexImagerFile)item.Tag);
                }
                if (SelectedFileMouseDoubleClick != null)
                {
                    SelectedFileMouseDoubleClick(this, new HexImagerFileSelectedEventArgs(recordings));
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METEC
{
    public partial class HexImagerFileSelectForm : Form
    {
        public HexImagerFileSelectForm()
        {
            InitializeComponent();
            hexImagerFileSelectControl.Initialize();
            hexImagerFileSelectControl.SelectedFileMouseDoubleClick += recordingsListView_MouseDoubleClick;
        }

        public HexImagerFileSelectForm(string path)
        {
            InitializeComponent();
            hexImagerFileSelectControl.Initialize(path);
            hexImagerFileSelectControl.SelectedFileMouseDoubleClick += recordingsListView_MouseDoubleClick;
        }

        // Recording viewer event delegate
        public event EventHandler<HexImagerFileSelectedEventArgs> SelectedFileMouseDoubleClick;
        private void recordingsListView_MouseDoubleClick(object sender, HexImagerFileSelectedEventArgs e)
        {
            if (SelectedFileMouseDoubleClick != null)
            {
                SelectedFileMouseDoubleClick(this, e);
            }
        }
    }
}

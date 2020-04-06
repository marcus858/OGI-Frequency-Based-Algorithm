using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METEC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string photoDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\";

            Application.Run(new HexImagerFileSelectForm(photoDir));
        }
    }
}

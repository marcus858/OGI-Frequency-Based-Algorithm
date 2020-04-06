using System;
using System.IO;
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
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new TestMainForm());
            var info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests\");
            var map = new HexImagerDirectoryMap(info);
            foreach (var imageFile in map)
            {
                Console.WriteLine(imageFile.Timestamp.ToString("yyyy-MM-ddTHH-mm-ss-ffffff"));
                foreach (var flirFile in imageFile)
                    Console.WriteLine(flirFile.Info.Name);
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var filesystem = new HexImagerFilesystem(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests 2\");
            var map = filesystem.MapFilenames();
            var imageFile = map.First();

            var writer = new HexImagerVideoWriter(imageFile);
            writer.WriteFile(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR Tests 2\testVideo.avi");
        }
    }
}

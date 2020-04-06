///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Class to manage operations in a HexImager recording directory
///-----------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace METEC
{
    public class HexImagerFilesystem
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Output directory path
        public static string TIMESTAMP_FORMAT = "yyyy-MM-ddTHH-mm-ss-ffffff";
        public string Path { get; set; }

        // Constructors
        public HexImagerFilesystem()
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\FLIR\";
        }
        public HexImagerFilesystem(string path)
        {
            Path = path;
        }

        // Create recording file name
        public string CreateFileName(int index, DateTime timestamp, string extension)
        {
            string timestampString = timestamp.ToString(TIMESTAMP_FORMAT);

            string fname = string.Format("camera_{0}_{1}", index, timestampString) + extension;
            _logger.Debug("METEC Filesystem", "Recording filename - " + fname);
            return Path + fname;
        }

        public HexImagerDirectoryMap MapFilenames()
        {
            return new HexImagerDirectoryMap(new DirectoryInfo(Path));
        }
    }
}

///-----------------------------------------------------------------
///    Author: Ian Smithpeter
///    Date: 2018-07-18
///    Description: Map of directory containing HexImagerRecordings
///-----------------------------------------------------------------

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace METEC
{
    public class HexImagerDirectoryMap : IEnumerable<HexImagerFile>
    {
        // Process logging
        private ConsoleLogger _logger = new ConsoleLogger(LogPriority.Debug);

        // Output directory path
        public static string TIMESTAMP_FORMAT = "yyyy-MM-ddTHH-mm-ss-ffffff";

        public DirectoryInfo Info { get; private set; }
        private SortedDictionary<DateTime, HexImagerFile> _map = new SortedDictionary<DateTime, HexImagerFile>();
        public List<DateTime> Keys { get { return _map.Keys.ToList(); } }

        // Constructors
        public HexImagerDirectoryMap() { }
        public HexImagerDirectoryMap(DirectoryInfo info)
        {
            Map(info);
        }

        // Make class enumerable
        public IEnumerator<HexImagerFile> GetEnumerator()
        {
            foreach (var recording in _map)
                yield return recording.Value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Map(DirectoryInfo info)
        {
            Info = info;
            IEnumerable<FileInfo> fileList = Info.GetFiles("camera_*_*.seq"); // ("*_[0-9]{19}*");
                                                                   // Create the query.  
            var queryGroupByTimestamp =
                from file in fileList
                group file by file.Name.Split('.')[0].Split('_')[2] into fileGroup
                orderby fileGroup.Key
                select fileGroup;

            foreach (var group in queryGroupByTimestamp)
            {
                try
                {
                    DateTime timestamp;
                    if (long.TryParse(group.Key, out long fileTime))
                    {
                        Console.WriteLine("Parsing file time {0}, {1}", group.Key, fileTime);
                        timestamp = DateTime.FromFileTime(fileTime);
                    }
                    else
                    {
                        Console.WriteLine("Parsing datetime format {0}", group.Key);
                        timestamp = DateTime.ParseExact(group.Key, TIMESTAMP_FORMAT, null);
                    }

                    var imageFile = new HexImagerFile(timestamp);
                    imageFile.Add(group.ToList());
                    _map.Add(timestamp, imageFile);
                }
                catch (FormatException exception)
                {
                    _logger.Info("Hex Imager Directory Map", String.Format("Invalid timestamp in file '{0}' - {1}", group.Key, exception.Message));
                }
            }
        }
    }
}

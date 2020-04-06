using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METEC
{
    public class HexImagerFileSelectedEventArgs : EventArgs
    {
        // The full path to the file.
        public List<HexImagerFile> Recordings { get; private set; }

        public HexImagerFileSelectedEventArgs(List<HexImagerFile> recordings)
        {
            Recordings = recordings;
        }
    }
}

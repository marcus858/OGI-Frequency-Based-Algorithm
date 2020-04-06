using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deprecated
{
    public class HexImagerExportStatusEventArgs : EventArgs
    {
        public readonly int TotalFrames;
        public readonly int CompletedFrames;
        public readonly int Index;

        public HexImagerExportStatusEventArgs(int totalFrames, int completedFrames, int index = -1)
        {
            TotalFrames = totalFrames;
            CompletedFrames = completedFrames;
            Index = index;
        }
    }
}

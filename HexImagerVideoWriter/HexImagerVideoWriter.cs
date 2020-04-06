using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Accord.Video.FFMPEG;

namespace METEC
{
    public class HexImagerVideoWriter
    {
        private HexImagerFile _imageFile;

        public HexImagerVideoWriter() { }

        public HexImagerVideoWriter(HexImagerFile imageFile)
        {
            _imageFile = imageFile;
            _imageFile.FileOpen = true;
        }

        public void WriteFile(string path)
        {
            var writer = new VideoFileWriter();
            writer.Open(path, 320*3, 240*2, 10, VideoCodec.MPEG4);

            _imageFile.SelectedIndex = 0;

            while (_imageFile.SelectedIndex < _imageFile.FrameCount)
            {
                writer.WriteVideoFrame(StitchImages());
                _imageFile.Next();
            }

            writer.Close();
        }

        private Bitmap StitchImages()
        {
            var bitmap = new Bitmap(320 * 3, 240 * 2);

            var graphics = Graphics.FromImage(bitmap);

            foreach (var imageFile in _imageFile)
            {
                imageFile.ImageFile.EnterLock();

                try
                {
                    int xPos = imageFile.Index % 3 * imageFile.ImageFile.Width;
                    int yPos = imageFile.Index / 3 * imageFile.ImageFile.Height;

                    graphics.DrawImage(imageFile.ImageFile.Image, new Point(xPos, yPos));
                }
                finally
                {
                    imageFile.ImageFile.ExitLock();
                }
            }

            return bitmap;
        }
    }
}

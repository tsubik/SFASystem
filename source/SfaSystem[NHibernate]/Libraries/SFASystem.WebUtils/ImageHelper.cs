using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace SFASystem.WebUtils
{
    public class ImageHelper
    {
 
        /// <summary>
        /// Calculates picture dimensions whilst maintaining aspect
        /// </summary>
        /// <param name="OriginalSize">The original picture size</param>
        /// <param name="TargetSize">The target picture size (longest side)</param>
        /// <returns></returns>
        public static Size CalculateDimensions(Size OriginalSize, int TargetSize)
        {
            Size newSize = new Size();
            if (OriginalSize.Height > OriginalSize.Width) // portrait 
            {
                newSize.Width = (int)(OriginalSize.Width * (float)(TargetSize / (float)OriginalSize.Height));
                newSize.Height = TargetSize;
            }
            else // landscape or square
            {
                newSize.Height = (int)(OriginalSize.Height * (float)(TargetSize / (float)OriginalSize.Width));
                newSize.Width = TargetSize;
            }
            return newSize;
        }


        /// <summary>
        /// Validates input picture dimensions
        /// </summary>
        /// <param name="PictureBinary">PictureBinary</param>
        /// <returns></returns>
        public static byte[] ValidatePicture(byte[] PictureBinary)
        {
            using (MemoryStream stream = new MemoryStream(PictureBinary))
            {
                Bitmap b = new Bitmap(stream);
                int maxSize = 1024;

                if ((b.Height > maxSize) || (b.Width > maxSize))
                {
                    Size newSize = CalculateDimensions(b.Size, maxSize);
                    Bitmap newBitMap = new Bitmap(newSize.Width, newSize.Height);
                    Graphics g = Graphics.FromImage(newBitMap);
                    g.DrawImage(b, 0, 0, newSize.Width, newSize.Height);

                    MemoryStream m = new MemoryStream();
                    newBitMap.Save(m, ImageFormat.Jpeg);

                    newBitMap.Dispose();
                    b.Dispose();

                    return m.GetBuffer();
                }
                else
                {
                    b.Dispose();
                    return PictureBinary;
                }
            }
        }


        /// <summary>
        /// Gets the picture binary array
        /// </summary>
        /// <param name="fs">File stream</param>
        /// <param name="size">Picture size</param>
        /// <returns>Picture binary array</returns>
        public static byte[] GetPictureBits(Stream fs, int size)
        {
            byte[] img = new byte[size];
            fs.Read(img, 0, size);
            return img;
        }
    }
}

using ScreenShare.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ScreenShare
{
    class ImageUtil
    {

        /// <summary>
        /// 捕获指定区域屏幕截图
        /// </summary>
        /// <param name="r"></param>
        /// <param name="captureCursor"></param>
        /// <returns></returns>
        public static Bitmap CaptureScreenArea(Rectangle r, bool captureCursor)
        {
            try
            {
                Bitmap bitmap = new Bitmap(r.Width, r.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(r.X, r.Y, 0, 0, new Size(r.Width, r.Height), CopyPixelOperation.SourceCopy);
                if (captureCursor)
                {
                    Point p = ScreenRealSize.GetCursor();
                    g.DrawImage(Resources.Cursor, new Point(p.X - r.X, p.Y - r.Y));
                }
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 缩放图片
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="dest"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Bitmap ZoomImage(Bitmap bitmap, Size s, int scale)
        {
            try
            {
                if (scale != 0)
                {
                    s.Width = bitmap.Width * scale / 100;
                    s.Height = bitmap.Height * scale / 100;
                }
                Bitmap destBitmap = new Bitmap(s.Width, s.Height);
                Graphics g = Graphics.FromImage(destBitmap);
                g.DrawImage(bitmap, new Rectangle(0, 0, s.Width, s.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
                g.Dispose();
                bitmap.Dispose();
                return destBitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 按质量保存图片
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="path"></param>
        /// <param name="quality"></param>
        public static void QualitySave(Bitmap bitmap, int quality, string path)
        {
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bitmap.Save(path, jgpEncoder, myEncoderParameters);
            bitmap.Dispose();
        }

        /// <summary>
        /// 按质量保存图片到内存流
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="quality"></param>
        /// <param name="memoryStream"></param>
        public static void QualitySave(Bitmap bitmap, int quality, MemoryStream memoryStream)
        {
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bitmap.Save(memoryStream, jgpEncoder, myEncoderParameters);
            bitmap.Dispose();
        }

        /// <summary>
        /// 获取图片编码
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

    }


}
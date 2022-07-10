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

        // jpg图片的ImageCodecInfo
        private static readonly ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

        /// <summary>
        /// 捕获指定区域屏幕截图
        /// </summary>
        /// <param name="r">矩形</param>
        /// <param name="captureCursor">捕获光标</param>
        /// <returns>Bitmap</returns>
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
                    g.DrawImage(Resources.cursor, new Point(p.X - r.X, p.Y - r.Y));
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
        /// <param name="bitmap">图片bitmap</param>
        /// <param name="s">图片的尺寸</param>
        /// <param name="scale">缩放比例(0-100)</param>
        /// <returns>Bitmap</returns>
        public static Bitmap ZoomImage(Bitmap bitmap, Size s, int scale)
        {
            try
            {
                if (scale > 0)
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
        /// 按质量保存图片到内存流
        /// </summary>
        /// <param name="bitmap">图片bitmap</param>
        /// <param name="quality">图片质量(0-100)</param>
        /// <param name="memoryStream">MemoryStream</param>
        public static void QualitySave(Bitmap bitmap, int quality, MemoryStream memoryStream)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
            bitmap.Save(memoryStream, jpgEncoder, encoderParameters);
            bitmap.Dispose();
        }

        /// <summary>
        /// 获取图片编码
        /// </summary>
        /// <param name="format">图片类型</param>
        /// <returns>ImageCodecInfo</returns>
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
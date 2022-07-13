using ScreenShare.Properties;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ScreenShare
{

    /********** 图像工具类 **********/
    internal class ImageUtils
    {

        /// <summary>
        /// 默认图像格式
        /// </summary>
        private static readonly ImageFormat defaultFormat = ImageFormat.Jpeg;
        /// <summary>
        /// 默认图像的ImageCodecInfo
        /// </summary>
        private static readonly ImageCodecInfo defaultEncoder = GetEncoder(defaultFormat);

        /// <summary>
        /// 捕获指定区域屏幕截图
        /// </summary>
        /// <param name="r">矩形</param>
        /// <param name="captureCursor">捕获光标</param>
        /// <returns>Bitmap</returns>
        public static Bitmap CaptureScreenArea(Rectangle r, bool captureCursor)
        {
            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(r.X, r.Y, 0, 0, r.Size, CopyPixelOperation.SourceCopy);
                if (captureCursor)
                {
                    Point p = Control.MousePosition;
                    g.DrawImage(Resources.cursor, new Point(p.X - r.X, p.Y - r.Y));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 缩放图片
        /// <para>原图片和目的图片尺寸不同时sourceBitmap会被释放掉</para>
        /// </summary>
        /// <param name="sourceBitmap">源图片bitmap</param>
        /// <param name="size">指定目的图片的尺寸</param>
        /// <returns>Bitmap</returns>
        public static Bitmap ZoomImage(Bitmap sourceBitmap, Size size)
        {
            if (sourceBitmap.Size == size)
            {
                return sourceBitmap;
            }
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, size.Width, size.Height), 0, 0, sourceBitmap.Width, sourceBitmap.Height, GraphicsUnit.Pixel);
            }
            sourceBitmap.Dispose();
            return bitmap;
        }

        /// <summary>
        /// 保存图片到内存流
        /// <para>bitmap会被释放掉</para>
        /// </summary>
        /// <param name="bitmap">图片bitmap</param>
        /// <param name="memoryStream">MemoryStream</param>
        public static void Save(Bitmap bitmap, MemoryStream memoryStream)
        {
            bitmap.Save(memoryStream, defaultFormat);
            bitmap.Dispose();
        }

        /// <summary>
        /// 按质量保存图片到内存流
        /// <para>图片质量&lt;=0或>=100时，保存原图</para>
        /// <para>bitmap会被释放掉</para>
        /// </summary>
        /// <param name="bitmap">图片bitmap</param>
        /// <param name="quality">图片质量(0-100)</param>
        /// <param name="memoryStream">MemoryStream</param>
        public static void QualitySave(Bitmap bitmap, int quality, MemoryStream memoryStream)
        {
            if (quality <= 0 || quality >= 100)
            {
                bitmap.Save(memoryStream, defaultFormat);
            }
            else
            {
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                bitmap.Save(memoryStream, defaultEncoder, encoderParameters);
            }
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

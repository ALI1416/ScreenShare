using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenShare
{
    /// <summary>
    /// 获取屏幕缩放后分辨率，使用前必须初始化Init()
    /// </summary>
    public class ScreenRealSize
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(
        IntPtr hdc, // handle to DC
        int nIndex // index of capability
        );
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        const int HORZRES = 8;
        const int VERTRES = 10;
        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;
        public static Size WorkingArea;
        public static Size DESKTOP;
        public static int DpiX;
        public static int DpiY;
        public static int ScaleX;
        public static int ScaleY;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int capsW = GetDeviceCaps(hdc, HORZRES);
            int capsH = GetDeviceCaps(hdc, VERTRES);
            int capsDW = GetDeviceCaps(hdc, DESKTOPHORZRES);
            int capsDH = GetDeviceCaps(hdc, DESKTOPVERTRES);
            int capsX = GetDeviceCaps(hdc, LOGPIXELSX);
            int capsY = GetDeviceCaps(hdc, LOGPIXELSY);
            WorkingArea = new Size
            {
                Width = capsW,
                Height = capsH
            };
            DESKTOP = new Size
            {
                Width = capsDW,
                Height = capsDH
            };
            DpiX = capsX;
            DpiY = capsY;
            ScaleX = 100 * capsDW / capsW;
            ScaleY = 100 * capsDH / capsH;
            ReleaseDC(IntPtr.Zero, hdc);
        }

        /// <summary>
        /// 转换坐标点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Point ConvertPoint(Point p)
        {
            return new Point
            {
                X = ScaleX * p.X / 100,
                Y = ScaleY * p.Y / 100
            };
        }

        /// <summary>
        /// 转换矩形坐标
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Rectangle ConvertRectangle(Rectangle r)
        {
            return new Rectangle
            {
                X = ScaleX * r.X / 100,
                Y = ScaleY * r.Y / 100,
                Width = ScaleX * r.Width / 100,
                Height = ScaleY * r.Height / 100
            };
        }

        /// <summary>
        /// 获得光标坐标
        /// </summary>
        /// <returns></returns>
        public static Point GetCursor()
        {
            return ConvertPoint(Control.MousePosition);
        }

    }
}

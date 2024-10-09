using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShare
{

    /// <summary>
    /// 选取屏幕
    /// </summary>
    public partial class DrawScreen : Form
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rect">绘图的Rectangle</param>
        public DrawScreen(Rectangle rect)
        {
            InitializeComponent();
            Location = rect.Location;
            Size = rect.Size;
        }

        /// <summary>
        /// 填充
        /// </summary>
        private readonly Brush brush = new SolidBrush(Color.White);
        /// <summary>
        /// 正在绘画
        /// </summary>
        private bool isDraw;
        /// <summary>
        /// 起始点
        /// </summary>
        private Point start;
        /// <summary>
        /// 结果Rectangle
        /// </summary>
        public Rectangle rect;

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawScreen_MouseDown(object sender, MouseEventArgs e)
        {
            isDraw = true;
            start = e.Location;
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDraw) return;
            rect = new Rectangle(Math.Min(start.X, e.X), Math.Min(start.Y, e.Y), Math.Abs(start.X - e.X) + 1, Math.Abs(start.Y - e.Y) + 1);
            Refresh();
        }

        /// <summary>
        /// 鼠标抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawScreen_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;
            // 防止越界
            if (rect.X < 0)
            {
                rect.X = 0;
            }
            if (rect.Y < 0)
            {
                rect.Y = 0;
            }
            if (rect.Width > Size.Width - rect.X)
            {
                rect.Width = Size.Width - rect.X;
            }
            if (rect.Height > Size.Height - rect.Y)
            {
                rect.Height = Size.Height - rect.Y;
            }
            // 返回父窗口对应的Rectangle
            rect = new Rectangle(rect.X + Location.X, rect.Y + Location.Y, rect.Width, rect.Height);
            DialogResult = DialogResult.OK;
            Close();
            brush.Dispose();
            Dispose();
        }

        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawScreen_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC键
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                brush.Dispose();
                Dispose();
            }
        }

        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brush, rect);
        }

    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class DrawScreen : Form
    {
        public DrawScreen()
        {
            InitializeComponent();
            // 获取到所有的屏幕信息
            Screen[] screens = Screen.AllScreens;
        //this.Location = new Point(-500, 500);
        //this.Size = new Size(1000,1000);
    }
    public Rectangle ResultRect { get; set; }
        private bool _canDraw;
        private int _startX, _startY;
        private Rectangle _rect;

        private void DrawScreen_MouseDown(object sender, MouseEventArgs e)
        {
            _canDraw = true;
            _startX = e.X;
            _startY = e.Y;
        }

        private void DrawScreen_MouseUp(object sender, MouseEventArgs e)
        {
            _canDraw = false;
            ResultRect = _rect;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DrawScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_canDraw) return;
            int x = Math.Min(_startX, e.X);
            int y = Math.Min(_startY, e.Y);
            int width = Math.Max(_startX, e.X) - Math.Min(_startX, e.X);
            int height = Math.Max(_startY, e.Y) - Math.Min(_startY, e.Y);
            _rect = new Rectangle(x, y, width, height);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, _rect);
        }

        private void DrawScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

    }
}

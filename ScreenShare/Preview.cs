using System.Drawing;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新预览图
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        public void UpdateImg(Bitmap bitmap)
        {
            if (img.Image != null)
            {
                img.Image.Dispose();
                img.Image = null;
            }
            img.Image = bitmap;
        }

    }
}

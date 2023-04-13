using ScreenShare.ScheduledTask;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShare
{

    /// <summary>
    /// 预览
    /// </summary>
    public partial class Preview : Form
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public Preview()
        {
            InitializeComponent();
            // FPS
            fpsLabel.Parent = img;
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

        /// <summary>
        /// 自动刷新
        /// </summary>
        public void AutoRefresh()
        {
            if (Visible)
            {
                ScheduledTasks.FpsAutoRefresh(this, fpsLabel, true);
            }
        }

        /// <summary>
        /// 开启窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Preview_Activated(object sender, System.EventArgs e)
        {
            fpsLabel.Text = "0.00 FPS";
        }

        /// <summary>
        /// 关闭窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Preview_Deactivate(object sender, System.EventArgs e)
        {
            if (img.Image != null)
            {
                img.Image.Dispose();
                img.Image = null;
            }
        }

    }
}

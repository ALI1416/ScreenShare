using ScreenShare.Model;
using ScreenShare.Util;
using System.Drawing;
using System.Windows.Forms;
using Z.QRCodeEncoder.Net;

namespace ScreenShare
{

    /// <summary>
    /// 网站二维码
    /// </summary>
    public partial class Qr : Form
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public Qr()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开启窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Qr_Load(object sender, System.EventArgs e)
        {
            QRCode qrCode = new QRCode(FormManager.ScreenShare.ShareLinkText(), 1);
            Bitmap bitmap = ImageUtils.QrBytes2Bitmap(qrCode.Matrix, 20);
            if (img.Image != null)
            {
                img.Image.Dispose();
                img.Image = null;
            }
            img.Image = bitmap;
        }

        /// <summary>
        /// 关闭窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Qr_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (img.Image != null)
            {
                img.Image.Dispose();
                img.Image = null;
            }
        }

    }
}

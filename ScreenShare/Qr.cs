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
            // HTTP://192.168.123.102:12345/ 分享地址最多29字节 v2l2m1最多容纳29字节
            QRCode qrCode = new QRCode(FormManager.Main.GetShareLink().ToUpperInvariant(), 2);
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

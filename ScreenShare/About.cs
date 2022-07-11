using System.Diagnostics;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void AuthorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ALI1416/ScreenShare");
        }

        private void ThankLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/EslaMx7/ScreenTask");
        }

        private void ThankLink2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xChivalrouSx/CaptureScreen");
        }
    }
}

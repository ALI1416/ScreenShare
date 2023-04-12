using ScreenShare.Model;
using ScreenShare.ScheduledTask;
using System;
using System.Windows.Forms;

namespace ScreenShare
{

    /// <summary>
    /// 应用程序的主入口点
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new ScheduledTasks();
            ScreenShare screenShare = new ScreenShare();
            FormManager.ScreenShare = screenShare;
            Application.Run(screenShare);
        }

    }
}

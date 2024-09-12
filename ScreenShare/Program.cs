using ScreenShare.Model;
using ScreenShare.ScheduledTask;
using System;
using System.Windows.Forms;

namespace ScreenShare
{

    /// <summary>
    /// 应用程序的主入口点
    /// </summary>
    public static class Program
    {

        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new ScheduledTasks();
            FormManager.Main = new Main();
            Application.Run(FormManager.Main);
        }

    }
}

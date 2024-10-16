using ScreenShare.Model;
using ScreenShare.ScheduledTask;
using ScreenShare.Util;
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
#if DEBUG
            FormManager.Main = new Main();
            Application.Run(FormManager.Main);
#else

            try
            {
                FormManager.Main = new Main();
                Application.Run(FormManager.Main);
            }
            catch (Exception e)
            {
                Utils.ShowError("程序错误！\n" + e);
            }
#endif
        }

    }
}

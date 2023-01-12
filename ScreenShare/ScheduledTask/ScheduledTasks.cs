using System.Threading;

namespace ScreenShare.ScheduledTask
{

    /// <summary>
    /// 定时任务
    /// </summary>
    public class ScheduledTasks
    {

        public static ScreenShare screenShare;
        public static History history;

        /// <summary>
        /// 启动定时任务
        /// </summary>
        public static void Start(ScreenShare screenShare)
        {
            ScheduledTasks.screenShare = screenShare;
            new ScheduledTasks();
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        private ScheduledTasks()
        {
            new Thread(t =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    screenShare.AutoRefresh();
                    if (history != null)
                    {
                        history.AutoRefresh();
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }

    }
}

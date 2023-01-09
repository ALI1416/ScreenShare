using System.Threading;

namespace ScreenShare.Task
{

    /// <summary>
    /// 定时任务
    /// </summary>
    public class Tasks
    {

        public static ScreenShare screenShare;
        public static History history;

        /// <summary>
        /// 启动定时任务
        /// </summary>
        public static void Start(ScreenShare screenShare)
        {
            Tasks.screenShare = screenShare;
            new Tasks();
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        private Tasks()
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

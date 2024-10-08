using ScreenShare.Model;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ScreenShare.ScheduledTask
{

    /// <summary>
    /// 定时任务
    /// </summary>
    public class ScheduledTasks
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public ScheduledTasks()
        {
            new Thread(t =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    if (FormManager.Main != null)
                    {
                        FormManager.Main.AutoRefresh();
                    }
                    if (FormManager.History != null)
                    {
                        FormManager.History.AutoRefresh();
                    }
                    if (FormManager.Preview != null)
                    {
                        FormManager.Preview.AutoRefresh();
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }

        /// <summary>
        /// fps自动刷新
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="fpsLabel">Label</param>
        /// <param name="notZero">是否显示非0</param>
        public static void FpsAutoRefresh(Control control, Label fpsLabel, bool notZero)
        {
            string text;
            if (notZero && StatusManager.IsStarted)
            {
                text = (StatusManager.WebSocketService.Server.FrameAvg / 100f).ToString("0.00") + " FPS";
            }
            else
            {
                text = "0.00 FPS";
            }
            Action<string> action = (data) =>
            {
                fpsLabel.Text = data;
            };
            control.Invoke(action, text);
        }

    }
}

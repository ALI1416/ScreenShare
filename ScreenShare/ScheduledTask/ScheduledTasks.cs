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
                    if (FormManager.ScreenShare != null)
                    {
                        FormManager.ScreenShare.AutoRefresh();
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
        public static void FpsAutoRefresh(Control control, Label fpsLabel)
        {
            string text;
            if (StatusManager.WebSocketService.Server() == null)
            {
                text = "0.00 FPS";
            }
            else
            {
                if (control != null && control.Visible)
                {
                    text = (StatusManager.WebSocketService.Server().FrameAvg / 100f).ToString("0.00") + " FPS";
                }
                else
                {
                    text = "0.00 FPS";
                }
            }
            Action<string> action = (data) =>
            {
                fpsLabel.Text = data;
            };
            control.Invoke(action, text);
        }

    }
}

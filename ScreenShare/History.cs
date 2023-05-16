using ScreenShare.Model;
using System;
using System.Windows.Forms;

namespace ScreenShare
{

    /// <summary>
    /// 用户在线历史
    /// </summary>
    public partial class History : Form
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public History()
        {
            InitializeComponent();
            Init(false);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Init(bool onlyOnline)
        {
            tableDataGridView.Rows.Clear();
            var now = DateTime.Now;
            int online = 0;
            if (StatusManager.WebSocketService == null)
            {
                return;
            }
            var list = StatusManager.WebSocketService.ClientList();
            foreach (var socketClient in list)
            {
                // 仅显示在线
                if (onlyOnline)
                {
                    // 在线
                    if (socketClient.Offline == DateTime.MinValue)
                    {
                        online++;
                        int index = tableDataGridView.Rows.Add();
                        tableDataGridView.Rows[index].Cells[0].Value = "在线";
                        tableDataGridView.Rows[index].Cells[1].Value = socketClient.Ip;
                        tableDataGridView.Rows[index].Cells[2].Value = socketClient.Online.ToString("HH:mm:ss.fff");
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(now.Subtract(socketClient.Online).TotalMinutes).ToString("0.00");
                        tableDataGridView.Rows[index].Cells[5].Value = (socketClient.FrameAvg / 100f).ToString("0.00");
                        tableDataGridView.Rows[index].Cells[6].Value = (socketClient.ByteAvg / 1024f).ToString("0.00");
                        tableDataGridView.Rows[index].Cells[7].Value = (socketClient.ByteCount / 1048576f).ToString("0.00");
                    }
                }
                else
                {
                    int index = tableDataGridView.Rows.Add();
                    tableDataGridView.Rows[index].Cells[1].Value = socketClient.Ip;
                    tableDataGridView.Rows[index].Cells[2].Value = socketClient.Online.ToString("HH:mm:ss.fff");
                    tableDataGridView.Rows[index].Cells[7].Value = (socketClient.ByteCount / 1048576f).ToString("0.00");
                    // 在线
                    if (socketClient.Offline == DateTime.MinValue)
                    {
                        online++;
                        tableDataGridView.Rows[index].Cells[0].Value = "在线";
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(now.Subtract(socketClient.Online).TotalMinutes).ToString("0.00");
                        tableDataGridView.Rows[index].Cells[5].Value = (socketClient.FrameAvg / 100f).ToString("0.00");
                        tableDataGridView.Rows[index].Cells[6].Value = (socketClient.ByteAvg / 1024f).ToString("0.00");
                    }
                    // 离线
                    else
                    {
                        tableDataGridView.Rows[index].Cells[3].Value = socketClient.Offline.ToString("HH:mm:ss.fff");
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(socketClient.Offline.Subtract(socketClient.Online).TotalMinutes).ToString("0.00");
                    }
                }
            }
            string text = "当前在线用户数量：" + online + "        累计访问用户数量：" + list.Length + "        当前帧率(帧/秒)：";
            if (StatusManager.WebSocketService.Server == null)
            {
                text += "0.00        传输数据总量(Mb)：0.00";
            }
            else
            {
                if (now.Subtract(StatusManager.WebSocketService.Server.LastRecordTime).TotalSeconds < 10)
                {
                    text += (StatusManager.WebSocketService.Server.FrameAvg / 100f).ToString("0.00");
                }
                else
                {
                    text += "0.00";
                }
                text += "        传输数据总量(Mb)：" + (StatusManager.WebSocketService.Server.ByteCount / 1048576f).ToString("0.00");
            }
            textLabel.Text = text;
        }

        /// <summary>
        /// 仅显示在线用户CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlyOnlineCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            Init(onlyOnlineCb.Checked);
        }

        /// <summary>
        /// 点击手动刷新链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshLinkLabel_Click(object sender, EventArgs e)
        {
            Init(onlyOnlineCb.Checked);
        }

        /// <summary>
        /// 自动刷新
        /// </summary>
        public void AutoRefresh()
        {
            if (Visible && autoRefreshCb.Checked)
            {
                Action action = () =>
                {
                    Init(onlyOnlineCb.Checked);
                };
                Invoke(action);
            }
        }

    }
}

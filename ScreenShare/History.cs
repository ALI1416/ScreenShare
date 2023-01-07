using ScreenShare.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class History : Form
    {

        /// <summary>
        /// socket服务端
        /// </summary>
        private readonly SocketServer socketServer;
        /// <summary>
        /// socket客户端
        /// </summary>
        private readonly List<SocketClient> socketClientList = new List<SocketClient>();

        public History(SocketServer socketServer, List<SocketClient> socketClientList)
        {
            InitializeComponent();
            this.socketServer = socketServer;
            this.socketClientList = socketClientList;
            Init(false);
            new Thread(t =>
            {
                AutoRefresh();
            })
            {
                IsBackground = true
            }.Start();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Init(bool onlyOnline)
        {
            tableDataGridView.Rows.Clear();
            var now = DateTime.Now;
            int online = 0;
            var list = socketClientList.ToArray();
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
                    // 下线
                    else
                    {
                        tableDataGridView.Rows[index].Cells[3].Value = socketClient.Offline.ToString("HH:mm:ss.fff");
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(socketClient.Offline.Subtract(socketClient.Online).TotalMinutes).ToString("0.00");
                    }
                }
            }
            if (socketServer == null)
            {
                textLabel.Text = "当前在线用户数量：" + online
                    + "        累计访问用户数量：" + list.Length
                    + "        当前帧率(帧/秒)：0"
                    + "        传输数据总量(Mb)：0";
            }
            else
            {
                textLabel.Text = "当前在线用户数量：" + online
                    + "        累计访问用户数量：" + list.Length
                    + "        当前帧率(帧/秒)：" + (socketServer.FrameAvg / 100f).ToString("0.00")
                    + "        传输数据总量(Mb)：" + (socketServer.ByteCount / 1048576f).ToString("0.00");
            }
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
        /// 5秒自动刷新
        /// </summary>
        private void AutoRefresh()
        {
            Thread.Sleep(1000);
            while (Visible)
            {
                if (autoRefreshCb.Checked)
                {
                    Action action = () =>
                    {
                        Init(onlyOnlineCb.Checked);
                    };
                    Invoke(action);
                }
                Thread.Sleep(5000);
            }
        }

    }
}

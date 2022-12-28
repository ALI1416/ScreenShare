using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class History : Form
    {

        /// <summary>
        /// socket客户端历史
        /// </summary>
        private Dictionary<int, SocketHistory> socketClientHistory;

        public History(Dictionary<int, SocketHistory> socketClientHistory)
        {
            InitializeComponent();
            this.socketClientHistory = socketClientHistory;
            Init(false);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Init(bool onlyOnline)
        {
            tableDataGridView.Rows.Clear();
            var array = socketClientHistory.ToArray();
            var now = DateTime.Now;
            int online = 0;
            foreach (var history in array)
            {
                var value = history.Value;
                if (onlyOnline)
                {
                    if (value.Offline == DateTime.MinValue)
                    {
                        online++;
                        int index = tableDataGridView.Rows.Add();
                        tableDataGridView.Rows[index].Cells[0].Value = "在线";
                        tableDataGridView.Rows[index].Cells[1].Value = value.Ip;
                        tableDataGridView.Rows[index].Cells[2].Value = value.Online.ToString("HH:mm:ss.fff");
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(now.Subtract(value.Online).TotalMinutes).ToString("0.00");
                    }
                }
                else
                {
                    int index = tableDataGridView.Rows.Add();
                    tableDataGridView.Rows[index].Cells[1].Value = value.Ip;
                    tableDataGridView.Rows[index].Cells[2].Value = value.Online.ToString("HH:mm:ss.fff");
                    if (value.Offline == DateTime.MinValue)
                    {
                        online++;
                        tableDataGridView.Rows[index].Cells[0].Value = "在线";
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(now.Subtract(value.Online).TotalMinutes).ToString("0.00");
                    }
                    else
                    {
                        tableDataGridView.Rows[index].Cells[3].Value = value.Offline.ToString("HH:mm:ss.fff");
                        tableDataGridView.Rows[index].Cells[4].Value = Convert.ToDouble(value.Offline.Subtract(value.Online).TotalMinutes).ToString("0.00");
                    }
                }
            }
            countLabel.Text = "累计访问用户数量：" + array.Length;
            onlineCountLabel.Text = "当前在线用户数量：" + online;
        }

        /// <summary>
        /// 仅显示在线用户CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlyOnlineCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            Init(onlyOnlineCheckBox.Checked);
        }

        /// <summary>
        /// 点击刷新链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshLinkLabel_Click(object sender, EventArgs e)
        {
            Init(onlyOnlineCheckBox.Checked);
        }

    }
}

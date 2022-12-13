using System;

namespace ScreenShare
{

    /// <summary>
    /// socket客户端历史
    /// </summary>
    public class SocketHistory
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { set; get; }
        /// <summary>
        /// 上线时间
        /// </summary>
        public DateTime Online { set; get; }
        /// <summary>
        /// 下线时间(`DateTime.MinValue`表示未下线)
        /// </summary>
        public DateTime Offline { set; get; }

        public SocketHistory(string ip, DateTime online)
        {
            Ip = ip;
            Online = online;
        }

    }
}

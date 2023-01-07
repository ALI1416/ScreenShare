using System;
using System.Net.Sockets;

namespace ScreenShare.Model
{
    /// <summary>
    /// socket服务端
    /// </summary>
    public class SocketServer
    {
        /// <summary>
        /// 服务端
        /// </summary>
        public Socket Server { get; set; }
        /// <summary>
        /// 上一次记录时间
        /// </summary>
        public DateTime LastRecordTime { set; get; }
        /// <summary>
        /// 帧总数
        /// </summary>
        public int FrameCount { set; get; }
        /// <summary>
        /// 平均每秒帧数x100
        /// </summary>
        public int FrameAvg { set; get; }
        /// <summary>
        /// 字节总数
        /// </summary>
        public int ByteCount { set; get; }

        /// <summary>
        /// 创建服务端
        /// </summary>
        public SocketServer()
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            LastRecordTime = DateTime.Now;
        }

        /// <summary>
        /// 关闭服务端
        /// </summary>
        public void Close()
        {
            if (Server != null)
            {
                Server.Close();
                Server = null;
            }
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="length">字节长度</param>
        public void Record(int length)
        {
            ByteCount += length;
            // 每5帧采样一次
            if ((++FrameCount) % 5 == 0)
            {
                var now = DateTime.Now;
                FrameAvg = (int)(500 / now.Subtract(LastRecordTime).TotalSeconds);
                LastRecordTime = now;
            }
        }

    }
}

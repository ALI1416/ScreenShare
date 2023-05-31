using System;
using System.Net.Sockets;

namespace ScreenShare.Model
{

    /// <summary>
    /// webSocket客户端
    /// </summary>
    public class WebSocketClient
    {

        /// <summary>
        /// 接收数据缓冲区长度，超出部分将丢弃
        /// </summary>
        public static readonly int MAX_BUFFER_LENGTH = 4096;

        /// <summary>
        /// 客户端
        /// </summary>
        public Socket Client { set; get; }
        /// <summary>
        /// 接收数据缓冲区
        /// </summary>
        public byte[] Buffer { set; get; }
        /// <summary>
        /// 数据接收长度
        /// </summary>
        private int length;
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
        /// <summary>
        /// 数据传输中
        /// </summary>
        public bool Transmission { set; get; }
        /// <summary>
        /// 上一次记录时间
        /// </summary>
        public DateTime LastRecordTime { set; get; }
        /// <summary>
        /// 上一次记录字节数
        /// </summary>
        public int LastRecordByte { set; get; }
        /// <summary>
        /// 帧总数
        /// </summary>
        public int FrameCount { set; get; }
        /// <summary>
        /// 字节总数
        /// </summary>
        public int ByteCount { set; get; }
        /// <summary>
        /// 平均每秒帧数x100
        /// </summary>
        public int FrameAvg { set; get; }
        /// <summary>
        /// 平均每秒字节数
        /// </summary>
        public int ByteAvg { set; get; }

        /// <summary>
        /// 数据接收长度
        /// </summary>
        public int Length
        {
            set { length = value; }
            get { return length > MAX_BUFFER_LENGTH ? MAX_BUFFER_LENGTH : length; }
        }

        /// <summary>
        /// 创建客户端
        /// </summary>
        /// <param name="socket">Socket</param>
        public WebSocketClient(Socket socket)
        {
            Client = socket;
            Buffer = new byte[MAX_BUFFER_LENGTH];
            Length = 0;
            Ip = socket.RemoteEndPoint.ToString();
            Online = DateTime.Now;
        }

        /// <summary>
        /// 关闭客户端
        /// </summary>
        public void Close()
        {
            if (Client != null)
            {
                Client.Close();
                Client = null;
                Buffer = null;
                Offline = DateTime.Now;
            }
        }

        /// <summary>
        /// 记录访问
        /// </summary>
        /// <param name="length">字节长度</param>
        public void RecordAccess(int length)
        {
            ByteCount += length;
            LastRecordByte += length;
            // 每5帧采样一次
            if ((++FrameCount) % 5 == 0)
            {
                var now = DateTime.Now;
                var second = now.Subtract(LastRecordTime).TotalSeconds;
                FrameAvg = (int)(500 / second);
                ByteAvg = (int)(LastRecordByte / second);
                LastRecordTime = now;
                LastRecordByte = 0;
            }
        }

    }
}

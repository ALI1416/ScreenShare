using System.Net.Sockets;

namespace ScreenShare.Model
{

    /// <summary>
    /// http客户端
    /// </summary>
    public class HttpClient
    {
        /// <summary>
        /// 客户端
        /// </summary>
        public Socket Client { set; get; }
        /// <summary>
        /// 接收数据缓冲区
        /// </summary>
        public byte[] Buffer { set; get; }

        /// <summary>
        /// 创建客户端
        /// </summary>
        /// <param name="client">Socket</param>
        /// 
        public HttpClient(Socket client)
        {
            Client = client;
            Buffer = new byte[1024];
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
            }
        }

    }
}

using System.Net.Sockets;

namespace ScreenShare.Model
{

    /// <summary>
    /// http客户端
    /// </summary>
    public class HttpClient
    {

        /// <summary>
        /// 接收数据缓冲区长度，超出将响应失败
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
        /// 创建客户端
        /// </summary>
        /// <param name="socket">Socket</param>
        /// 
        public HttpClient(Socket socket)
        {
            Client = socket;
            Buffer = new byte[MAX_BUFFER_LENGTH];
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

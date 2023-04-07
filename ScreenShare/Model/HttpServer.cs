using System.Net.Sockets;

namespace ScreenShare.Model
{

    /// <summary>
    /// http服务端
    /// </summary>
    public class HttpServer
    {
        /// <summary>
        /// 服务端
        /// </summary>
        public Socket Server { get; set; }

        /// <summary>
        /// 创建服务端
        /// </summary>
        public HttpServer()
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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

    }
}

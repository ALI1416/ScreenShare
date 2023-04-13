using ScreenShare.Model;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace ScreenShare.BLL
{

    /// <summary>
    /// http服务
    /// </summary>
    public class HttpService
    {

        /// <summary>
        /// 服务器
        /// </summary>
        private HttpServer server;
        /// <summary>
        /// 请求消息处理函数&lt;路径,参数,返回值>
        /// </summary>
        private Func<string, NameValueCollection, byte[]> requestHandleFunc;

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="requestHandleFunc">request处理函数&lt;路径,参数,返回值></param>
        /// <returns>是否启动成功</returns>
        public bool Start(IPAddress ip, int port, Func<string, NameValueCollection, byte[]> requestHandleFunc)
        {
            try
            {
                // 新建服务器
                server = new HttpServer();
                // 指定IP地址和端口号
                server.Server.Bind(new IPEndPoint(ip, port));
                // 设置监听数量
                server.Server.Listen(10);
                // 异步监听客户端请求
                server.Server.BeginAccept(Handle, null);
                this.requestHandleFunc = requestHandleFunc;
            }
            // 端口号冲突、未知错误
            catch
            {
                server.Close();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            server.Close();
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void Handle(IAsyncResult ar)
        {
            try
            {
                // 继续异步监听客户端请求
                server.Server.BeginAccept(Handle, null);
            }
            // 主动关闭服务器
            catch
            {
                return;
            }
            // 客户端上线
            ClientOnline(server.Server.EndAccept(ar));
        }

        /// <summary>
        /// 客户端上线
        /// </summary>
        /// <param name="socket">客户端</param>
        private void ClientOnline(Socket socket)
        {
            HttpClient client = null;
            try
            {
                client = new HttpClient(socket);
                // 设置超时10秒
                socket.SendTimeout = 10000;
                // 接收消息
                socket.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, Recevice, client);
            }
            catch
            {
                if (client != null)
                {
                    client.Close();
                }
                return;
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void Recevice(IAsyncResult ar)
        {
            // 获取当前客户端
            HttpClient client = ar.AsyncState as HttpClient;
            try
            {
                // 获取接收数据长度
                int length = client.Client.EndReceive(ar);
                // 客户端主动断开连接时，会发送0字节消息
                if (length == 0)
                {
                    client.Close();
                    return;
                }
                // 解码消息
                string msg = Encoding.UTF8.GetString(client.Buffer, 0, length);
                // 请求消息处理
                RequestHandle(client, msg);
                // 关闭连接
                client.Close();
            }
            // 超时后失去连接、未知错误
            catch
            {
                client.Close();
                return;
            }
        }

        /// <summary>
        /// 请求消息处理
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="msg">请求消息</param>
        private void RequestHandle(HttpClient client, string msg)
        {
            string[] pathAndQuery = HttpUtility.UrlDecode(msg.Substring(4, msg.IndexOf('\r') - 13)).Split('?');
            string path = pathAndQuery[0];
            NameValueCollection param = null;
            if (pathAndQuery.Length > 1)
            {
                param = HttpUtility.ParseQueryString(pathAndQuery[1]);
            }
            // 请求消息处理函数
            byte[] data = requestHandleFunc(path, param);
            Send(client, data);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="data">byte[]</param>
        private void Send(HttpClient client, byte[] data)
        {
            try
            {
                // 发送消息
                client.Client.BeginSend(data, 0, data.Length, SocketFlags.None, null, null);
            }
            // 未知错误
            catch
            {
                client.Close();
                return;
            }
        }

    }
}

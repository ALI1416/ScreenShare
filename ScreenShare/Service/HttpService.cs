using ScreenShare.Model;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace ScreenShare.Service
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
        /// 响应回调函数&lt;路径,参数,返回值>
        /// </summary>
        private Func<string, NameValueCollection, byte[]> responseCallback;

        /// <summary>
        /// html头
        /// </summary>
        public static readonly string htmlHeader = "HTTP/1.0 200 OK\nContent-Type: text/html;charset=utf-8\nConnection: close\n\n";
        /// <summary>
        /// json头
        /// </summary>
        public static readonly string jsonHeader = "HTTP/1.0 200 OK\nContent-Type: application/json;charset=utf-8\nConnection: close\n\n";
        /// <summary>
        /// ico头byte[]
        /// </summary>
        public static readonly byte[] icoHeaderBytes = Encoding.UTF8.GetBytes("HTTP/1.0 200 OK\nContent-Type: image/x-icon\nConnection: close\n\n");

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="responseCallback">响应回调函数&lt;路径,参数,返回值></param>
        /// <returns>是否启动成功</returns>
        public bool Start(IPAddress ip, int port, Func<string, NameValueCollection, byte[]> responseCallback)
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
            }
            // 端口号冲突
            catch
            {
                server.Close();
                server = null;
                return false;
            }
            this.responseCallback = responseCallback;
            return true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (server != null)
            {
                server.Close();
            }
        }

        /// <summary>
        /// 获取byte[]
        /// </summary>
        /// <param name="header">http头字符串</param>
        /// <param name="content">内容</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBytes(string header, string content)
        {
            return Encoding.UTF8.GetBytes(header + content);
        }

        /// <summary>
        /// 获取byte[]
        /// </summary>
        /// <param name="headerBytes">http头byte[]</param>
        /// <param name="stream">MemoryStream</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBytes(byte[] headerBytes, MemoryStream stream)
        {
            byte[] data = new byte[headerBytes.Length + stream.Length];
            headerBytes.CopyTo(data, 0);
            stream.ToArray().CopyTo(data, headerBytes.Length);
            return data;
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
                ClientOnline(server.Server.EndAccept(ar));
            }
            // 主动关闭服务器
            catch
            {
                return;
            }
            // 客户端上线
        }

        /// <summary>
        /// 客户端上线
        /// </summary>
        /// <param name="socket">Socket</param>
        private void ClientOnline(Socket socket)
        {
            HttpClient client = null;
            try
            {
                client = new HttpClient(socket);
                // 接收消息
                socket.BeginReceive(client.Buffer, 0, HttpClient.MAX_BUFFER_LENGTH, SocketFlags.None, Recevice, client);
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
                // 请求消息处理
                RequestHandle(client, length);
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
        /// <param name="client">客户端</param>
        /// <param name="length">消息长度</param>
        private void RequestHandle(HttpClient client, int length)
        {
            // 解码消息
            string msg = Encoding.UTF8.GetString(client.Buffer, 0, length);
            // 路径、参数
            string[] pathAndQuery = HttpUtility.UrlDecode(msg.Substring(4, msg.IndexOf('\r') - 13)).Split('?');
            // 路径
            string path = pathAndQuery[0];
            // 参数
            NameValueCollection param = null;
            if (pathAndQuery.Length > 1)
            {
                param = HttpUtility.ParseQueryString(pathAndQuery[1]);
            }
            // 响应回调函数
            byte[] data = responseCallback(path, param);
            Send(client, data);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="data">消息</param>
        private void Send(HttpClient client, byte[] data)
        {
            try
            {
                // 发送消息
                client.Client.BeginSend(data, 0, data.Length, SocketFlags.None, null, null);
            }
            // 已失去连接、未知错误
            catch
            {
                client.Close();
                return;
            }
        }

    }
}

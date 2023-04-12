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
        /// http服务端
        /// </summary>
        private HttpServer HttpServer { get; set; }
        /// <summary>
        /// request处理函数&lt;路径,参数,返回值>
        /// </summary>
        private Func<string, NameValueCollection, byte[]> requestHandle;

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="endPoint">IP地址和端口号</param>
        /// <param name="requestHandle">request处理函数&lt;路径,参数,返回值></param>
        /// <returns>是否启动成功</returns>
        public bool Start(EndPoint endPoint, Func<string, NameValueCollection, byte[]> requestHandle)
        {
            try
            {
                // 新建http服务器
                HttpServer = new HttpServer();
                // 指定IP地址和端口号
                HttpServer.Server.Bind(endPoint);
                // 设置监听数量
                HttpServer.Server.Listen(10);
                // 异步监听客户端请求
                HttpServer.Server.BeginAccept(Handle, null);
                this.requestHandle = requestHandle;
            }
            // 端口号冲突、未知错误
            catch
            {
                HttpServer.Close();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            HttpServer.Close();
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
                HttpServer.Server.BeginAccept(Handle, null);
            }
            // 主动关闭http服务器
            catch
            {
                return;
            }
            // 客户端上线
            ClientOnline(HttpServer.Server.EndAccept(ar));
        }

        /// <summary>
        /// 客户端上线
        /// </summary>
        /// <param name="client">客户端</param>
        private void ClientOnline(Socket client)
        {
            HttpClient httpClient = null;
            try
            {
                httpClient = new HttpClient(client);
                // 设置超时10秒
                client.SendTimeout = 10000;
                // 接收消息
                client.BeginReceive(httpClient.Buffer, 0, httpClient.Buffer.Length, SocketFlags.None, Recevice, httpClient);
            }
            catch
            {
                if (httpClient != null)
                {
                    httpClient.Close();
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
            HttpClient httpClient = ar.AsyncState as HttpClient;
            try
            {
                // 获取接收数据长度
                int length = httpClient.Client.EndReceive(ar);
                // 客户端主动断开连接时，会发送0字节消息
                if (length == 0)
                {
                    httpClient.Close();
                    return;
                }
                // 解码消息
                string msg = Encoding.UTF8.GetString(httpClient.Buffer, 0, length);
                // httpRequest处理
                RequestHandle(httpClient, msg);
                // 关闭连接
                httpClient.Close();
            }
            // 超时后失去连接、未知错误
            catch
            {
                httpClient.Close();
                return;
            }
        }

        /// <summary>
        /// request处理
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="request">request字符串</param>
        private void RequestHandle(HttpClient httpClient, string request)
        {
            string[] pathAndQuery = HttpUtility.UrlDecode(request.Substring(4, request.IndexOf('\r') - 13)).Split('?');
            string path = pathAndQuery[0];
            NameValueCollection param = null;
            if (pathAndQuery.Length > 1)
            {
                param = HttpUtility.ParseQueryString(pathAndQuery[1]);
            }
            // request处理函数
            byte[] data = requestHandle(path, param);
            Send(httpClient, data);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="data">byte[]</param>
        private void Send(HttpClient httpClient, byte[] data)
        {
            try
            {
                // 发送消息
                httpClient.Client.BeginSend(data, 0, data.Length, SocketFlags.None, null, null);
            }
            // 未知错误
            catch
            {
                httpClient.Close();
                return;
            }
        }

    }
}

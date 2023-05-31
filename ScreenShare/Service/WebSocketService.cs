using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ScreenShare.Model;
using ScreenShare.Util;

namespace ScreenShare.Service
{

    /// <summary>
    /// webSocket服务
    /// </summary>
    public class WebSocketService
    {

        /// <summary>
        /// 服务器
        /// </summary>
        private WebSocketServer server;
        /// <summary>
        /// 客户端列表
        /// </summary>
        private List<WebSocketClient> clientList;
        /// <summary>
        /// 客户端上下线回调函数&lt;客户端,上线或下线>
        /// </summary>
        private Action<WebSocketClient, bool> clientCallback;

        /// <summary>
        /// 关闭连接头byte[]
        /// </summary>
        private readonly static byte[] closeHeaderBytes = Encoding.UTF8.GetBytes("HTTP/1.0 200 OK\nConnection: close\n\n");

        /// <summary>
        /// 获取服务端
        /// </summary>
        /// <returns>WebSocketServer</returns>
        public WebSocketServer Server
        {
            get { return server; }
        }

        /// <summary>
        /// 获取服务端的端口号
        /// </summary>
        /// <returns>端口号</returns>
        public int ServerPort()
        {
            return ((IPEndPoint)server.Server.LocalEndPoint).Port;
        }

        /// <summary>
        /// 获取客户端列表
        /// </summary>
        /// <returns>客户端列表</returns>
        public WebSocketClient[] ClientList()
        {
            return clientList.ToArray();
        }

        /// <summary>
        /// 获取在线客户端列表
        /// </summary>
        /// <returns>在线客户端列表</returns>
        public List<WebSocketClient> ClientOnlineList()
        {
            return clientList.FindAll(e => e.Client != null);
        }

        /// <summary>
        /// 获取在线客户端数量
        /// </summary>
        /// <returns>在线客户端数量</returns>
        public int ClientOnlineCount()
        {
            return clientList.FindAll(e => e.Client != null).Count;
        }

        /// <summary>
        /// 获取`在线`并且`可发送数据`的客户端列表
        /// </summary>
        /// <returns>`在线`并且`可发送数据`的客户端列表</returns>
        public List<WebSocketClient> ClientOnlineAndNotTransmission()
        {
            return clientList.FindAll(e => (e.Client != null && !e.Transmission));
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="clientCallback">客户端上下线回调函数&lt;客户端,上线或下线></param>
        /// <returns>是否启动成功</returns>
        public bool Start(IPAddress ip, int port, Action<WebSocketClient, bool> clientCallback)
        {
            try
            {
                // 新建服务器
                server = new WebSocketServer(server);
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
            if (clientList == null)
            {
                clientList = new List<WebSocketClient>();
            }
            this.clientCallback = clientCallback;
            return true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (server != null)
            {
                foreach (WebSocketClient client in ClientOnlineList())
                {
                    ClientOffline(client);
                }
                server.Close();
            }
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
        /// <param name="socket">Socket</param>
        private void ClientOnline(Socket socket)
        {
            // 已存在
            if (clientList.Exists(e => e.Client == socket))
            {
                return;
            }
            WebSocketClient client = null;
            try
            {
                client = new WebSocketClient(socket);
                // 接收消息
                socket.BeginReceive(client.Buffer, 0, WebSocketClient.MAX_BUFFER_LENGTH, SocketFlags.None, Recevice, client);
                clientList.Add(client);
                // 客户端上线回调函数
                clientCallback(client, true);
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
        /// 客户端下线
        /// </summary>
        /// <param name="client">客户端</param>
        private void ClientOffline(WebSocketClient client)
        {
            // 不存在
            if (!ClientOnlineList().Contains(client))
            {
                return;
            }
            client.Close();
            // 客户端下线回调函数
            clientCallback(client, false);
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void Recevice(IAsyncResult ar)
        {
            // 获取当前客户端
            WebSocketClient client = ar.AsyncState as WebSocketClient;
            try
            {
                // 获取接收数据长度
                int length = client.Client.EndReceive(ar);
                // 客户端主动断开连接时，会发送0字节消息
                if (length == 0)
                {
                    ClientOffline(client);
                    return;
                }
                client.Length += length;
                // 消息全部接收完毕
                if (client.Client.Available == 0)
                {
                    // 首次连接
                    if (client.Buffer[0] == 71)
                    {
                        // 请求握手
                        if (!HandShake(client))
                        {
                            return;
                        }
                    }
                    else
                    {
                        // 解码消息
                        byte[] data = WebSocketUtils.DecodeData(client.Buffer, client.Length);
                        // 客户端请求关闭连接
                        if (data == null)
                        {
                            ClientOffline(client);
                        }
                        else
                        {
                            client.Transmission = false;
                        }
                    }
                    client.Length = 0;
                    // 继续接收消息
                    client.Client.BeginReceive(client.Buffer, 0, WebSocketClient.MAX_BUFFER_LENGTH, SocketFlags.None, Recevice, client);
                }
                // 消息还未全部接收
                else
                {
                    // 计算可用容量
                    int available = WebSocketClient.MAX_BUFFER_LENGTH - length;
                    // 丢弃溢出消息
                    if (available == 0)
                    {
                        client.Client.BeginReceive(new byte[WebSocketClient.MAX_BUFFER_LENGTH], 0, WebSocketClient.MAX_BUFFER_LENGTH, SocketFlags.None, Recevice, client);
                    }
                    // 继续接收消息
                    else
                    {
                        client.Client.BeginReceive(client.Buffer, client.Length, available, SocketFlags.None, Recevice, client);
                    }
                }
            }
            // 超时后失去连接、未知错误
            catch
            {
                ClientOffline(client);
                return;
            }
        }

        /// <summary>
        /// 请求握手
        /// </summary>
        /// <param name="client">客户端</param>
        /// <returns>是否已请求握手</returns>
        private bool HandShake(WebSocketClient client)
        {
            // 解码消息
            string msg = Encoding.UTF8.GetString(client.Buffer, 0, client.Length);
            // 获取握手信息
            byte[] data = WebSocketUtils.HandShake(msg);
            if (data != null)
            {
                // 发送握手信息
                SendRaw(client, data);
                return true;
            }
            // 无法握手
            else
            {
                // 关闭连接
                SendRaw(client, closeHeaderBytes);
                client.Close();
                return false;
            }
        }

        /// <summary>
        /// 发送二进制消息 给指定客户端列表
        /// </summary>
        /// <param name="list">客户端列表</param>
        /// <param name="data">二进制消息</param>
        public void SendDataByClientList(List<WebSocketClient> list, byte[] data)
        {
            byte[] msg = WebSocketUtils.CodedData(data, false);
            foreach (WebSocketClient client in list)
            {
                client.Transmission = true;
                client.RecordAccess(data.Length);
                SendRaw(client, msg);
            }
        }

        /// <summary>
        /// 发送原始消息
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="data">原始消息</param>
        private void SendRaw(WebSocketClient client, byte[] data)
        {
            try
            {
                // 发送消息
                client.Client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    try
                    {
                        int length = client.Client.EndSend(asyncResult);
                    }
                    // 已失去连接
                    catch
                    {
                        ClientOffline(client);
                        return;
                    }
                }, null);
            }
            // 未知错误
            catch
            {
                ClientOffline(client);
                return;
            }
        }

    }
}

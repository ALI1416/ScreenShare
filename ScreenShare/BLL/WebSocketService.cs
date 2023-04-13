using ScreenShare.Model;
using ScreenShare.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ScreenShare.BLL
{

    /// <summary>
    /// webSocket服务
    /// </summary>
    public class WebSocketService
    {

        /// <summary>
        /// 关闭连接byte[]
        /// </summary>
        private static readonly byte[] closeHeaderBytes = Encoding.UTF8.GetBytes("HTTP/1.0 200 OK\nConnection: close\n\n");

        /// <summary>
        /// 服务器
        /// </summary>
        private WebSocketServer server;
        /// <summary>
        /// 客户端列表
        /// </summary>
        private List<WebSocketClient> clientList;
        /// <summary>
        /// 客户端状态处理函数&lt;IP地址,上线或下线>
        /// </summary>
        private Action<string, bool> clientStatusHandleFunc;

        /// <summary>
        /// 获取服务端
        /// </summary>
        /// <returns>WebSocketServer</returns>
        public WebSocketServer Server()
        {
            return server;
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
        /// 设置服务端记录日志
        /// </summary>
        /// <param name="length">字节长度</param>
        public void ServerRecord(int length)
        {
            server.Record(length);
        }

        /// <summary>
        /// 获取客户端列表
        /// </summary>
        /// <returns>WebSocketClient[]</returns>
        public WebSocketClient[] ClientList()
        {
            return clientList.ToArray();
        }

        /// <summary>
        /// 获取在线用户数量
        /// </summary>
        /// <returns>在线用户数量</returns>
        public int ClientOnlineCount()
        {
            return clientList.FindAll(e => e.Client != null).Count;
        }

        /// <summary>
        /// 获取`在线`并且`可发送数据`的用户列表
        /// </summary>
        /// <returns>List&lt;WebSocketClient></returns>
        public List<WebSocketClient> ClientOnlineAndNotTransmission()
        {
            return clientList.FindAll(e => (e.Client != null && !e.Transmission));
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="clientStatusHandleFunc">客户端状态处理函数&lt;IP地址,上线或下线></param>
        /// <returns>是否启动成功</returns>
        public bool Start(IPAddress ip, int port, Action<string, bool> clientStatusHandleFunc)
        {
            try
            {
                // 记录上次`字节总数`
                int byteCount = 0;
                if (server != null)
                {
                    byteCount = server.ByteCount;
                }
                // 新建服务器
                server = new WebSocketServer();
                // `字节总数`累加
                server.ByteCount += byteCount;
                // 指定IP地址和随机端口号
                server.Server.Bind(new IPEndPoint(ip, port));
                // 设置监听数量
                server.Server.Listen(10);
                // 异步监听客户端请求
                server.Server.BeginAccept(Handle, null);
                if (clientList == null)
                {
                    clientList = new List<WebSocketClient>();
                }
                this.clientStatusHandleFunc = clientStatusHandleFunc;
            }
            // 未知错误
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
            foreach (var client in clientList.FindAll(e => e.Client != null))
            {
                ClientOffline(client);
            }
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
            // 已存在
            if (clientList.Exists(e => e.Client == socket))
            {
                return;
            }
            WebSocketClient client = null;
            try
            {
                client = new WebSocketClient(socket);
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
        /// 客户端下线
        /// </summary>
        /// <param name="client">WebSocketClient</param>
        private void ClientOffline(WebSocketClient client)
        {
            // 不存在
            if (!clientList.FindAll(e => e.Client != null).Contains(client))
            {
                return;
            }
            client.Close();
            clientStatusHandleFunc(client.Ip, false);
        }

        /// <summary>
        /// 接收
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
                // 首次连接
                if (client.Buffer[0] == 71)
                {
                    // 解码消息
                    string msg = Encoding.UTF8.GetString(client.Buffer, 0, length);
                    // 获取握手信息
                    byte[] data = WebSocketUtils.HandShake(msg);
                    if (data != null)
                    {
                        // 发送握手信息
                        SendRaw(client, data);
                        // 继续接收消息
                        client.Client.BeginReceive(client.Buffer, 0, length, SocketFlags.None, Recevice, client);
                        clientList.Add(client);
                        clientStatusHandleFunc(client.Ip, true);
                    }
                    // 无法握手
                    else
                    {
                        // 关闭连接
                        SendRaw(client, closeHeaderBytes);
                        client.Close();
                        return;
                    }
                }
                else
                {
                    // 继续接收消息
                    client.Client.BeginReceive(client.Buffer, 0, length, SocketFlags.None, Recevice, client);
                    // 解码消息
                    string data = WebSocketUtils.DecodeDataString(client.Buffer, length);
                    // 客户端关闭连接
                    if (data == null)
                    {
                        ClientOffline(client);
                        return;
                    }
                    else
                    {
                        client.Transmission = false;
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
        /// 发送原始消息
        /// </summary>
        /// <param name="client">WebSocketClient</param>
        /// <param name="data">byte[]</param>
        private void SendRaw(WebSocketClient client, byte[] data)
        {
            try
            {
                // 发送消息
                client.Client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    try
                    {
                        client.Client.EndSend(asyncResult);
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

        /// <summary>
        /// 发送数据给指定用户列表
        /// </summary>
        /// <param name="data"></param>
        public void SendDataByClientList(List<WebSocketClient> clientList, byte[] data)
        {
            foreach (var client in clientList)
            {
                client.Record(data.Length);
                SendRaw(client, WebSocketUtils.CodedData(data, false));
            }
        }

    }
}

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
        /// webSocket服务端
        /// </summary>
        private WebSocketServer WebSocketServer { get; set; }
        /// <summary>
        /// webSocket客户端列表
        /// </summary>
        public List<WebSocketClient> WebSocketClientList { get; set; }
        /// <summary>
        /// 客户端状态处理函数&lt;IP地址,上线或下线>
        /// </summary>
        private Action<string, bool> clientStatusHandle;

        /// <summary>
        /// 获取webSocket服务端
        /// </summary>
        /// <returns>webSocket服务端的IP地址和端口号</returns>
        public WebSocketServer Server()
        {
            return WebSocketServer;
        }

        /// <summary>
        /// 获取webSocket服务端的IP地址和端口号
        /// </summary>
        /// <returns>webSocket服务端的IP地址和端口号</returns>
        public EndPoint ServerIpAndPort()
        {
            return WebSocketServer.Server.LocalEndPoint;
        }

        /// <summary>
        /// 设置webSocket服务端记录日志
        /// </summary>
        /// <param name="length">字节长度</param>
        public void ServerRecord(int length)
        {
            WebSocketServer.Record(length);
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="endPoint">IP地址和端口号</param>
        /// <param name="clientStatusHandle">客户端状态处理函数&lt;IP地址,上线或下线></param>
        /// <returns>是否启动成功</returns>
        public bool Start(EndPoint endPoint, Action<string, bool> clientStatusHandle)
        {
            try
            {
                // 记录上次`字节总数`
                int byteCount = 0;
                if (WebSocketServer != null)
                {
                    byteCount = WebSocketServer.ByteCount;
                }
                // 新建socket服务器
                WebSocketServer = new WebSocketServer();
                // `字节总数`累加
                WebSocketServer.ByteCount += byteCount;
                // 指定IP地址和随机端口号
                WebSocketServer.Server.Bind(endPoint);
                // 设置监听数量
                WebSocketServer.Server.Listen(10);
                // 异步监听客户端请求
                WebSocketServer.Server.BeginAccept(Handle, null);
                WebSocketClientList = new List<WebSocketClient>();
                this.clientStatusHandle = clientStatusHandle;
            }
            // 未知错误
            catch
            {
                WebSocketServer.Close();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            foreach (var socketClient in WebSocketClientList.FindAll(e => e.Client != null))
            {
                ClientOffline(socketClient);
            }
            WebSocketServer.Close();
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
                WebSocketServer.Server.BeginAccept(Handle, null);
            }
            // 主动关闭socket服务器
            catch
            {
                return;
            }
            // 客户端上线
            ClientOnline(WebSocketServer.Server.EndAccept(ar));
        }


        /// <summary>
        /// 客户端上线
        /// </summary>
        /// <param name="client">客户端</param>
        private void ClientOnline(Socket client)
        {
            // 已存在
            if (WebSocketClientList.Exists(e => e.Client == client))
            {
                return;
            }
            WebSocketClient socketClient = null;
            try
            {
                socketClient = new WebSocketClient(client);
                // 设置超时10秒
                client.SendTimeout = 10000;
                // 接收消息
                client.BeginReceive(socketClient.Buffer, 0, socketClient.Buffer.Length, SocketFlags.None, Recevice, socketClient);
            }
            catch
            {
                if (socketClient != null)
                {
                    socketClient.Close();
                }
                return;
            }
        }

        /// <summary>
        /// 客户端下线
        /// </summary>
        /// <param name="socketClient">SocketClient</param>
        private void ClientOffline(WebSocketClient socketClient)
        {
            // 不存在
            if (!WebSocketClientList.FindAll(e => e.Client != null).Contains(socketClient))
            {
                return;
            }
            socketClient.Close();
            clientStatusHandle(socketClient.Ip, false);
        }

        /// <summary>
        /// 接收
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void Recevice(IAsyncResult ar)
        {
            // 获取当前客户端
            WebSocketClient socketClient = ar.AsyncState as WebSocketClient;
            try
            {
                // 获取接收数据长度
                int length = socketClient.Client.EndReceive(ar);
                // 客户端主动断开连接时，会发送0字节消息
                if (length == 0)
                {
                    ClientOffline(socketClient);
                    return;
                }
                // 首次连接
                if (socketClient.Buffer[0] == 71)
                {
                    // 解码消息
                    string msg = Encoding.UTF8.GetString(socketClient.Buffer, 0, length);
                    // 获取握手信息
                    byte[] data = WebSocketUtils.HandShake(msg);
                    if (data != null)
                    {
                        // 发送握手信息
                        SendRaw(socketClient, data);
                        // 继续接收消息
                        socketClient.Client.BeginReceive(socketClient.Buffer, 0, length, SocketFlags.None, Recevice, socketClient);
                        WebSocketClientList.Add(socketClient);
                        clientStatusHandle(socketClient.Ip, true);
                    }
                    // 无法握手
                    else
                    {
                        // 关闭连接
                        SendRaw(socketClient, closeHeaderBytes);
                        socketClient.Close();
                        return;
                    }
                }
                else
                {
                    // 继续接收消息
                    socketClient.Client.BeginReceive(socketClient.Buffer, 0, length, SocketFlags.None, Recevice, socketClient);
                    // 解码消息
                    string data = WebSocketUtils.DecodeDataString(socketClient.Buffer, length);
                    // 客户端关闭连接
                    if (data == null)
                    {
                        ClientOffline(socketClient);
                        return;
                    }
                    else
                    {
                        socketClient.Transmission = false;
                    }
                }
            }
            // 超时后失去连接、未知错误
            catch
            {
                ClientOffline(socketClient);
                return;
            }
        }

        /// <summary>
        /// 发送原始消息
        /// </summary>
        /// <param name="socketClient">SocketClient</param>
        /// <param name="data">byte[]</param>
        private void SendRaw(WebSocketClient socketClient, byte[] data)
        {
            try
            {
                // 发送消息
                socketClient.Client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    try
                    {
                        socketClient.Client.EndSend(asyncResult);
                    }
                    // 已失去连接
                    catch
                    {
                        ClientOffline(socketClient);
                        return;
                    }
                }, null);
            }
            // 未知错误
            catch
            {
                ClientOffline(socketClient);
                return;
            }
        }

        /// <summary>
        /// 发送数据给指定用户
        /// </summary>
        /// <param name="data"></param>
        public void SendDataByClient(List<WebSocketClient> list, byte[] data)
        {
            foreach (var socketClient in list)
            {
                socketClient.Record(data.Length);
                SendRaw(socketClient, WebSocketUtils.CodedData(data, false));
            }
        }

    }
}

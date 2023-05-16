using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;

namespace ScreenShare.Util
{

    /// <summary>
    /// webSocket工具
    /// </summary>
    public class WebSocketUtils
    {

        /// <summary>
        /// 获取握手响应消息
        /// </summary>
        /// <param name="msg">握手请求消息</param>
        /// <returns>握手响应消息(无法握手返回null)</returns>
        public static byte[] HandShake(string msg)
        {
            StringReader reader = new StringReader(msg);
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    return null;
                }
                else if (line.Contains("Sec-WebSocket-Key"))
                {
                    byte[] secret = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(line.Substring(19) + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"));
                    string secretKey = Convert.ToBase64String(secret);
                    string data = "HTTP/1.1 101 Switching Protocols\nUpgrade: websocket\nConnection: Upgrade\nSec-WebSocket-Accept: " + secretKey + "\n\n";
                    return Encoding.UTF8.GetBytes(data);
                }
            }
        }

        /// <summary>
        /// 解码消息 并转为字符串
        /// </summary>
        /// <param name="msg">消息(不处理超过1帧的消息)</param>
        /// <param name="length">消息长度</param>
        /// <returns>解码后的字符串(返回null表示客户端请求关闭连接)</returns>
        public static string DecodeDataString(byte[] msg, int length)
        {
            byte[] data = DecodeData(msg, length);
            if (data == null)
            {
                return null;
            }
            else
            {
                return Encoding.UTF8.GetString(data);
            }
        }

        /// <summary>
        /// 解码消息
        /// </summary>
        /// <param name="msg">消息(不处理超过1帧的消息)</param>
        /// <param name="length">消息长度</param>
        /// <returns>解码后的消息(返回null表示客户端请求关闭连接)</returns>
        public static byte[] DecodeData(byte[] msg, int length)
        {
            // 长度太短、有后续帧、不包含mask
            if (length < 6 || msg[0] >> 7 != 1 || msg[1] >> 7 != 1)
            {
                return new byte[0];
            }
            // 检查opcode是否为关闭连接
            if ((msg[0] & 0x8) == 8)
            {
                return null;
            }
            // mask所在字节数
            int maskByte = 2;
            // 获取数据长度
            int len = msg[1] & 0x7F;
            if (len == 126)
            {
                maskByte = 4;
            }
            else if (len == 127)
            {
                maskByte = 12;
            }
            // mask
            byte[] mask = new byte[4];
            mask[0] = msg[maskByte];
            mask[1] = msg[maskByte + 1];
            mask[2] = msg[maskByte + 2];
            mask[3] = msg[maskByte + 3];
            // 解码前的数据
            byte[] data = new byte[length - maskByte - 4];
            Buffer.BlockCopy(msg, maskByte + 4, data, 0, data.Length);
            // 解码数据
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ mask[i % 4]);
            }
            return data;
        }

        /// <summary>
        /// 编码消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="isText">是否为文本消息</param>
        /// <returns>编码后的消息</returns>
        public static byte[] CodedData(byte[] msg, bool isText)
        {
            byte[] data;
            int length = msg.Length;
            if (length < 126)
            {
                data = new byte[length + 2];
                data[0] = (byte)(isText ? 0x81 : 0x82);
                data[1] = (byte)length;
                msg.CopyTo(data, 2);
            }
            else if (length < 0xFFFF)
            {
                data = new byte[length + 4];
                data[0] = (byte)(isText ? 0x81 : 0x82);
                data[1] = 126;
                data[2] = (byte)(length >> 8 & 0xFF);
                data[3] = (byte)(length & 0xFF);
                msg.CopyTo(data, 4);
            }
            else
            {
                data = new byte[length + 10];
                data[0] = (byte)(isText ? 0x81 : 0x82);
                data[1] = 127;
                data[2] = 0;
                data[3] = 0;
                data[4] = 0;
                data[5] = 0;
                data[6] = (byte)(length >> 24 & 0xFF);
                data[7] = (byte)(length >> 16 & 0xFF);
                data[8] = (byte)(length >> 8 & 0xFF);
                data[9] = (byte)(length & 0xFF);
                msg.CopyTo(data, 10);
            }
            return data;
        }

    }
}

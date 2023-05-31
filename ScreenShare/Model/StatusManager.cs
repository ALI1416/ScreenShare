using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System;
using ScreenShare.Service;

namespace ScreenShare.Model
{

    /// <summary>
    /// 运行状态管理器
    /// </summary>
    public class StatusManager
    {

        /// <summary>
        /// 屏幕共享已启动
        /// </summary>
        public static bool IsStarted { get; set; }
        /// <summary>
        /// IP地址列表
        /// </summary>
        public static List<Tuple<string, IPAddress>> IpList { get; set; }
        /// <summary>
        /// 屏幕信息列表
        /// </summary>
        public static List<Tuple<string, Rectangle>> ScreenList { get; set; }
        /// <summary>
        /// http服务
        /// </summary>
        public static HttpService HttpService { get; set; }
        /// <summary>
        /// webSocket服务
        /// </summary>
        public static WebSocketService WebSocketService { get; set; }

    }

}

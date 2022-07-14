using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ScreenShare
{

    /********** 工具类 **********/
    internal class Utils
    {

        /// <summary>
        /// 获取所有的IP地址
        /// </summary>
        /// <returns>List&lt;Tuple&lt;名称, IP地址&gt;&gt;</returns>
        public static List<Tuple<string, string>> GetAllIPv4Address()
        {
            var ipList = new List<Tuple<string, string>>();
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var ua in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ua.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipList.Add(Tuple.Create(ni.Name, ua.Address.ToString()));
                    }
                }
            }
            return ipList;
        }

        /// <summary>
        /// 获取所有屏幕信息
        /// <para>当有1个屏幕时，返回1个Tuple</para>
        /// <para>当有n个屏幕时，
        /// 第一个(下标0)是全部屏幕的叠加态，
        /// 第二个(下标1)是主屏幕，
        /// 后面是其他屏幕，
        /// 总共返回n+1个Tuple
        /// </para>
        /// </summary>
        /// <returns>List&lt;Tuple&lt;名称, 屏幕Rectangle&gt;&gt;</returns>
        public static List<Tuple<string, Rectangle>> GetAllScreen()
        {
            var screenList = new List<Tuple<string, Rectangle>>();
            var screens = Screen.AllScreens;
            int screenLength = screens.Length;
            if (screenLength == 1)
            {
                screenList.Add(Tuple.Create(screens[0].DeviceName.Remove(0, 11) + "(主)", screens[0].Bounds));
            }
            else
            {
                for (int i = 0; i < screenLength; i++)
                {
                    if (screens[i].Primary)
                    {
                        screenList.Insert(0, Tuple.Create(screens[i].DeviceName.Remove(0, 11) + "(主)", screens[i].Bounds));
                    }
                    else
                    {
                        screenList.Add(Tuple.Create(screens[i].DeviceName.Remove(0, 11), screens[i].Bounds));
                    }
                }
                // 计算全部屏幕的叠加态
                int xMin = screenList.Min(t => t.Item2.Left);
                int yMin = screenList.Min(t => t.Item2.Top);
                int xMax = screenList.Max(t => t.Item2.Right);
                int yMax = screenList.Max(t => t.Item2.Bottom);
                screenList.Insert(0, Tuple.Create("0(全)", new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin)));
            }
            return screenList;
        }

        /// <summary>
        /// 添加防火墙规则
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="port">端口号</param>
        public static void AddNetFw(string name, int port)
        {
            INetFwMgr netFwMgr = (INetFwMgr)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwMgr"));
            INetFwOpenPort openPort = (INetFwOpenPort)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwOpenPort"));
            openPort.Name = name;
            openPort.Port = port;
            openPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            openPort.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            openPort.Enabled = true;
            netFwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(openPort);
        }

    }
}

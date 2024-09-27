using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ScreenShare.Util
{

    /// <summary>
    /// 通用工具
    /// </summary>
    public class Utils
    {

        /// <summary>
        /// 获取所有的IP地址
        /// </summary>
        /// <returns>List Tuple IP地址名称, IP地址IPAddress</returns>
        public static List<Tuple<string, IPAddress>> GetAllIPv4Address()
        {
            var ipList = new List<Tuple<string, IPAddress>>();
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var ua in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ua.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipList.Add(Tuple.Create(ni.Name, ua.Address));
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
        /// <returns>List Tuple 屏幕名称, 屏幕Rectangle</returns>
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

    }
}

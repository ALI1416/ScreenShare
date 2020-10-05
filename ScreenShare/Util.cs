using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ScreenShare
{
    public static class Util
    {

        /// <summary>
        /// 获取所有的IP地址
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string>> GetAllIPv4Addresses()
        {
            List<Tuple<string, string>> ipList = new List<Tuple<string, string>>();
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
    }
}

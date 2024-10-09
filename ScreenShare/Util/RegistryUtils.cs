using Microsoft.Win32;
using ScreenShare.Model;

namespace ScreenShare.Util
{

    /// <summary>
    /// 注册表工具
    /// </summary>
    public class RegistryUtils
    {

        /// <summary>
        /// 自启路径
        /// </summary>
        public static readonly string AUTO_LAUNCH_PATH = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// 获取自启路径
        /// </summary>
        /// <param name="name">名称</param>
        public static string AutoLaunchGet(string name)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(AUTO_LAUNCH_PATH);
            string path = (string)registryKey.GetValue(name);
            registryKey.Close();
            return path;
        }

        /// <summary>
        /// 开启自启
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="path">路径</param>
        public static void AutoLaunchOpen(string name, string path)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(AUTO_LAUNCH_PATH, true);
            registryKey.SetValue(name, path, RegistryValueKind.String);
            registryKey.Close();
        }

        /// <summary>
        /// 开启自启
        /// </summary>
        public static void AutoLaunchOpen()
        {
            AutoLaunchOpen(Constant.APP_NAME, Constant.APP_PATH);
        }

        /// <summary>
        /// 关闭自启
        /// </summary>
        /// <param name="name">名称</param>
        public static void AutoLaunchClose(string name)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(AUTO_LAUNCH_PATH, true);
            if (registryKey.GetValue(name) != null)
            {
                registryKey.DeleteValue(name);
            }
            registryKey.Close();
        }

        /// <summary>
        /// 关闭自启
        /// </summary>
        public static void AutoLaunchClose()
        {
            AutoLaunchClose(Constant.APP_NAME);
        }

    }
}

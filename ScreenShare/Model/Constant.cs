using System;
using System.Reflection;

namespace ScreenShare.Model
{

    /// <summary>
    /// 常量
    /// </summary>
    public class Constant
    {

        /// <summary>
        /// APP名称(不含后缀)
        /// </summary>
        public static readonly string APP_NAME = Assembly.GetExecutingAssembly().GetName().Name;
        /// <summary>
        /// APP路径(完整路径+名称+后缀)
        /// </summary>
        public static readonly string APP_PATH = Assembly.GetExecutingAssembly().Location;
        /// <summary>
        /// 版本
        /// </summary>
        public static readonly Version VERSION = Assembly.GetExecutingAssembly().GetName().Version;
        /// <summary>
        /// 版本号(前3位)
        /// </summary>
        public static readonly string VERSION_NUMBER = VERSION.Major + "." + VERSION.Minor + "." + VERSION.Build;

        /// <summary>
        /// INI名称(名称+后缀)
        /// </summary>
        public static readonly string INI_NAME = APP_NAME + ".ini";
        /// <summary>
        /// INI目录(%APPDATA%)
        /// </summary>
        public static readonly string INI_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + APP_NAME;
        /// <summary>
        /// INI路径(完整路径+名称+后缀)
        /// </summary>
        public static readonly string INI_PATH = INI_DIRECTORY + "\\" + INI_NAME;

    }
}

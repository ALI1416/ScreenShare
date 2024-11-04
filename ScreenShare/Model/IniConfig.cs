using System.Collections.Generic;

namespace ScreenShare.Model
{

    /// <summary>
    /// INI配置
    /// </summary>
    public class IniConfig
    {

        /// <summary>
        /// 系统
        /// </summary>
        public class System
        {

            /// <summary>
            /// 开机自启
            /// </summary>
            public static bool AutoLaunch { get; set; } = false;
            /// <summary>
            /// 自动运行
            /// </summary>
            public static bool AutoRun { get; set; } = false;
            /// <summary>
            /// 开启黑名单
            /// </summary>
            public static bool OpenBlack { get; set; } = false;
            /// <summary>
            /// 开启白名单
            /// </summary>
            public static bool OpenWhite { get; set; } = false;

        }

        /// <summary>
        /// 程序
        /// </summary>
        public class Program
        {

            /// <summary>
            /// IP地址
            /// </summary>
            public static string IpAddress { get; set; }
            /// <summary>
            /// 端口号
            /// </summary>
            public static int IpPort { get; set; } = 7070;
            /// <summary>
            /// 开启密码验证
            /// </summary>
            public static bool IsEncryption { get; set; } = false;
            /// <summary>
            /// 密码
            /// </summary>
            public static string Pwd { get; set; } = "";
            /// <summary>
            /// 全屏显示
            /// </summary>
            public static bool IsFullScreen { get; set; } = true;
            /// <summary>
            /// 显示器
            /// </summary>
            public static string Screen { get; set; }
            /// <summary>
            /// 显示器X
            /// </summary>
            public static int? ScreenX { get; set; }
            /// <summary>
            /// 显示器Y
            /// </summary>
            public static int? ScreenY { get; set; }
            /// <summary>
            /// 显示器宽
            /// </summary>
            public static int? ScreenW { get; set; }
            /// <summary>
            /// 显示器高
            /// </summary>
            public static int? ScreenH { get; set; }
            /// <summary>
            /// 锁定纵横比
            /// </summary>
            public static bool IsLockAspectRatio { get; set; } = true;
            /// <summary>
            /// 缩放比例
            /// </summary>
            public static int Scaling { get; set; } = 100;
            /// <summary>
            /// 视频宽
            /// </summary>
            public static int? VideoW { get; set; }
            /// <summary>
            /// 视频高
            /// </summary>
            public static int? VideoH { get; set; }
            /// <summary>
            /// 显示光标
            /// </summary>
            public static bool IsDisplayCursor { get; set; } = true;
            /// <summary>
            /// 每秒帧数
            /// </summary>
            public static int VideoFrame { get; set; } = 5;
            /// <summary>
            /// 视频质量
            /// </summary>
            public static int VideoQuality { get; set; } = 100;

        }

        /// <summary>
        /// 黑名单
        /// </summary>
        public static List<string> BlackList { get; } = new List<string>();

        /// <summary>
        /// 白名单
        /// </summary>
        public static List<string> WriteList { get; } = new List<string>();

    }
}

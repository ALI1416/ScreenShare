namespace ScreenShare.Model
{

    /// <summary>
    /// Win窗体管理器
    /// </summary>
    public class FormManager
    {

        /// <summary>
        /// 主界面
        /// </summary>
        public static ScreenShare ScreenShare { get; set; }
        /// <summary>
        /// 系统配置
        /// </summary>
        public static Config Config { get; set; }
        /// <summary>
        /// 用户在线历史
        /// </summary>
        public static History History { get; set; }
        /// <summary>
        /// 预览
        /// </summary>
        public static Preview Preview { get; set; }
        /// <summary>
        /// 网站二维码
        /// </summary>
        public static Qr Qr { get; set; }

    }

}

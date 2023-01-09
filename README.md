# ScreenShare

## 屏幕共享

版本：2.3.0

## 主要功能

- 密码验证
- 支持多显示器
- 支持高DPI
- 自定义选择区域
- 视频尺寸调节
- 视频质量调节
- 视频帧数调节
- 光标显示
- 视频预览
- 托盘运行
- 访问用户详细信息

## 下载

[点击下载](https://gitee.com/ALI1416/ScreenShare/releases/download/v2.3.0/ScreenShare.zip)

## 软件截图

![软件截图](img/软件截图.png)

## 运行示例

![运行示例](img/运行示例.png)

## 历史版本

### v2.3.0 `2023.1.10`

- 新增功能
  1. 图片使用webSocket推流
  2. 前端页面显示`实时帧率`
  3. `主界面`的预览图上显示`实时帧率`
  4. `用户在线历史界面`显示更多信息
- 系统优化
  1. 仅在需要时捕获屏幕

### v2.2.0 `2022.12.13`

- 新增功能
  1. 图片使用socket推流
  2. `用户在线数量`和`用户在线历史`功能
  3. `清空日志`功能
- 系统优化
  1. 优化代码可读性
  2. 优化页面显示
  3. http服务器使用异步方式
  4. `每秒帧数`为`0`时以最快速度刷新
- 修复漏洞
  1. `选取屏幕坐标`宽和高都少`1`个像素

### v2.1.1 `2022.11.17`

- 系统优化
  1. 删除防火墙规则
- 修复漏洞
  1. 屏幕分辨率不是`1920x1080`启动后闪退
  2. 启动后立即点击`用浏览器打开`闪退

### v2.1.0 `2022.11.16`

- 新增功能
  1. 获取视频信息接口
- 系统优化
  1. 完善提示
  2. 美化网页
- 修复漏洞
  1. 屏幕分辨率不是`1920x1080`启动后闪退

### v2.0.1 `2022.7.16`

- 修复漏洞
  1. 视频尺寸返回给前端错误

### v2.0.0 `2022.7.16`

- 新增功能
  1. 支持多显示器
  2. 支持高DPI
  3. 托盘运行
- 系统优化
  1. `关于`使用`HTML`显示
  2. 屏幕截图优化
  3. 自定义选择区域优化
  4. 添加防火墙规则
- 修复漏洞
  1. 剪切板复制报错
  2. 外网无法访问

### v1.0.0 `2020.10.5`

- 支持功能
  1. 加密传输
  2. 自定义选择区域
  3. 视频尺寸调节
  4. 视频质量调节
  5. 视频帧数调节
  6. 光标显示
  7. 视频预览

## 致谢

[EslaMx7](https://github.com/EslaMx7/ScreenTask)

[xChivalrouSx](https://github.com/xChivalrouSx/CaptureScreen)

[MrKonstantinSh](https://github.com/MrKonstantinSh/OpenScreen)

## 项目链接

[Github](https://github.com/ALI1416/ScreenShare)

[Gitee](https://gitee.com/ALI1416/ScreenShare)

## 许可证

[![License](https://img.shields.io/badge/license-BSD-brightgreen)](https://opensource.org/licenses/BSD-3-Clause)

## 交流

- QQ：1416978277
- 微信：1416978277
- 支付宝：1416978277@qq.com

![交流](https://cdn.jsdelivr.net/gh/ALI1416/ALI1416/image/contact.png)

## 赞助

![赞助](https://cdn.jsdelivr.net/gh/ALI1416/ALI1416/image/donate.png)

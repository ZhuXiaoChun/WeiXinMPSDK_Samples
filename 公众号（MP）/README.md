# 当前项目为官方项目“Senparc.Weixin.MP Sample”的信息整理
**官方仓库地址：** https://github.com/JeffreySu/WeiXinMPSDK/tree/master/Samples/MP

**官方文档地址：** https://sdk.weixin.senparc.com/Docs/MP#title_setting


# 1/5，配置服务关键参数，并部署
## 公众号后台，基本设置
- 在项目中搜索“**#{微信公众号后台_基本设置_开发者Id(AppId)}#}**”，替换为微信公众号后台，基本设置目录下，公众号开发信息部分的，开发者ID(AppID)字段。
- 在项目中搜索“**#{微信公众号后台_基本设置_开发者密码(AppSecret)}#**”，替换为微信公众号后台，基本设置目录下，公众号开发信息部分的，开发者密码(AppSecret)字段。

## 公众号后台，服务器设置
- 在项目中搜索“**#{微信公众号后台_服务器设置_验证Token}}#**”，替换为微信公众号后台，基本设置目录下，服务器配置部分的，令牌(Token)
字段，注意该字段可随意填下，建议使用由随机英文和数字组成字符串。
- 在项目中搜索“**#{微信公众号后台_服务器设置_加密用AESKey}#**”，替换为微信公众号后台，基本设置目录下，服务器配置部分的，消息加解密密钥(EncodingAESKey)字段，注意：该字段只有在“消息加解密方式”为“安全模式”时才有意义。
- 公众号后台，基本设置目录下，服务器配置，服务器地址(URL)的配置路径为“**当前服务根目录/weixin/index**”。

## 当前服务，配置
- 在项目中搜索“**#{Http服务端口号}#**”，替换为当前服务使用的Http服务端口号。
- 在项目中搜索“**#{Https服务端口号}#**”，替换为当前服务使用的Https服务端口号，如不需要，可删除相关代码块。
- 在项目中搜索“**#{当前服务_根路径}#**”，替换为当前服务部署后的，当前服务根目录，如： https://test.com 。

## 当前服务，部署和验证
- 发布当前服务，并部署。
- 部署后，可在公众号后台，基本设置目录下，服务器配置，中点击“提交”进行验证。
- 部署后，可在公众号后台，基本设置目录下，IP白名单下设置当前服务服务器的公网IP地址，设置后可使用“**当前服务根目录/weixinJSSDK/index**”路径，验证IP白名单是否生效（如未生效，该页面会产生报错信息，可在服务的命令窗口中查看到详情）。

# 2/5，核心组件介绍

公众号服务使用的核心组件为“MessageHandler”，可以通过两种方法调用：
1. 使用“MessageHandler中间件”的方式：
```
app.UseMessageHandlerForMp("/WeixinAsync", CustomMessageHandler.GenerateMessageHandler, options =>
{
    options.AccountSettingFunc = context =>  Senparc.Weixin.Config.SenparcWeixinSetting;
});
```
对应的请求路径为：**当前服务根目录/weiXinAsync/实例方法名称** 。

2. 使用控制器的方式：
创建控制器，并调用“MessageHandler”实例，可参考项目中的“**Controllers/WeixinController.cs**”文件。
对应的请求路径为：**当前服务根目录/weiXin/index**  。

3. 可参考本项目中的“MessageHandlers/CustomMessageHandler.cs”文件，实现公众号常用功能。

# 3/5，微信JSSDK相关使用
- 使用JSSDK时，需要在公众号后台，基本设置目录下，IP白名单下设置当前服务服务器的公网IP地址，设置后可使用“**当前服务根目录/weixinJSSDK/index**”路径，验证IP白名单是否生效。
- 前端使用JSSDK，可参考本项目中的“**Views/WeixinJSSDK/Index.cshtml**”文件

# 4/5，OAuth授权相关使用
- 项目中的“**/Controllers/OAuth2Controller.cs**”文件，可供参考，用于生成微信登录授权Url。
- 【注意】公众号的OAuth授权，需要配合[【微信公众号，第三方平台功能】](https://open.weixin.qq.com/cgi-bin/frame?t=home/wx_plugin_tmpl&lang=zh_CN)使用。

# 5/5，其他信息
- 【模板消息】，由公众号推送给指定用户的固定格式消息，功能在【微信开发平台】中实现，而不在当前公众号项目样例中。
/*----------------------------------------------------------------
    Copyright (C) 2024 Senparc
    
    文件名：BaseController.cs
    文件功能描述：Controller基类
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using Microsoft.AspNetCore.Mvc;

namespace Senparc.Weixin.Sample.MP.Controllers;

public class BaseController : Controller
{
        ////////////////////////////////////////////////
        // @自身属性
        ////////////////////////////////////////////////

        #region 自身属性

        protected string AppId
        {
                get
                {
                        // 与微信公众账号后台的AppId设置保持一致，区分大小写。
                        return Config.SenparcWeixinSetting.WeixinAppId;
                }
        }

        protected static ISenparcWeixinSettingForMP MpSetting
        {
                get
                {
                        return Config.SenparcWeixinSetting.MpSetting;
                }
        }

        #endregion
}
//DPBMARK_FILE MP
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Helpers;

namespace Senparc.Weixin.Sample.MP.Controllers;

/// <summary>
/// JSSDK 的演示。
/// </summary>
public class WeixinJSSDKController : BaseController
{
	////////////////////////////////////////////////
	// @自身属性
	////////////////////////////////////////////////

	#region 自身属性

	readonly string _appId = Config.SenparcWeixinSetting.WeixinAppId;

	readonly string _appSecret = Config.SenparcWeixinSetting.WeixinAppSecret;

	#endregion


	////////////////////////////////////////////////
	// @自身实现
	////////////////////////////////////////////////

	#region 自身实现

	public async Task<ActionResult> Index()
	{
		var jssdkUiPackage = await JSSDKHelper.GetJsSdkUiPackageAsync(
			_appId,
			_appSecret,
			Request.AbsoluteUri());
		{ }
		return View(jssdkUiPackage);
	}

	#endregion
}

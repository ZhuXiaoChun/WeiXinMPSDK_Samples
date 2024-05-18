using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.Sample.Models;
using System.Diagnostics;

namespace Senparc.Weixin.Sample.TenPayV3.Controllers;

public class HomeController(ILogger<HomeController> logger) : BaseController
{
        ////////////////////////////////////////////////
        // @自身属性
        ////////////////////////////////////////////////

        #region 自身属性

        private readonly ILogger<HomeController> _logger = logger;

        #endregion
        #region 自身实现

        public IActionResult Index()
        {
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
}
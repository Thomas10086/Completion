using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Controllers
{
    public class ResController : Controller
    {
        // GET: Res
        /// <summary>
        /// 菜单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 权限分配
        /// </summary>
        /// <returns></returns>
        public ActionResult Power()
        {
            return View();
        }
    }
}
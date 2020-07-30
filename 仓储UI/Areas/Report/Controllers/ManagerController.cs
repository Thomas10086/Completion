using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Areas.Report.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Report/Manager
        /// <summary>
        /// 自定义报表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 新增报表
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
    }
}
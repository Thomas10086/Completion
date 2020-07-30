using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Areas.Bad.Controllers
{
    public class ProductController : Controller
    {
        // GET: Bad/Product
        /// <summary>
        /// 报损管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 新增报损
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
    }
}
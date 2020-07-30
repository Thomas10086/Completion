using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Areas.InStorage.Controllers
{
    public class ProductController : Controller
    {
        // GET: InStorage/Product
        /// <summary>
        /// 入库管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 新增入库
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

    }
}
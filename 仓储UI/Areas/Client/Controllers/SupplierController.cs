using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Areas.Client.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Client/Supplier
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
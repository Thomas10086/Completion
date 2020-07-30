using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Areas.Client.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Client/Customer
        /// <summary>
        /// 客户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
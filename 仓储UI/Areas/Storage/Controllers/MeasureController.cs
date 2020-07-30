using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储UI.Areas.Storage.Controllers
{
    public class MeasureController : Controller
    {
        // GET: Storage/Measure
        /// <summary>
        /// 计量单位
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView();
        }
    }
}
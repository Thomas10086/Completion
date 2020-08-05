using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Storage.Controllers
{
    public class MeasureController : Controller
    {
        Completion db = new Completion();
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
        [HttpGet]
        public ActionResult Upd(string id)
        {
            var info = db.BI_Measure.Find(id);
            return PartialView(info);
        }
    }
}
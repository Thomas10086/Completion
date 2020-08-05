using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Client.Controllers
{
    public class SupplierController : Controller
    {
        Completion db = new Completion();
        // GET: Client/Supplier
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var list = db.BI_SupType.ToList();
            var info = new BI_SupType { SupTypeID = 0, SupTypeName = "--请选择供应商类型--" };
            list.Insert(0, info);
            ViewBag.SupTypeList = new SelectList(list, "SupTypeID", "SupTypeName");
            return PartialView();
        }
        [HttpGet]
        public ActionResult Upd(string id)
        {
            var info = db.BI_Supplier.Find(id);
            var list = db.BI_SupType.ToList();
            ViewBag.SupTypeList = new SelectList(list, "SupTypeID", "SupTypeName", info.SupTypeID);
            return PartialView(info);
        }
    }
}
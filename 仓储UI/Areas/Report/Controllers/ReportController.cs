using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Report.Controllers
{
    public class ReportController : Controller
    {
        Completion db = new Completion();
        // GET: Report/Report
        /// <summary>
        /// 库存清单
        /// </summary>
        /// <returns></returns>
        public ActionResult StockBillReport()
        {
            var list1 = db.BI_LocaType.ToList();
            var info1 = new BI_LocaType { LocalTypeID = 0, LocalTypeName = "--请选择库位类型--" };
            list1.Insert(0, info1);
            ViewBag.LocalTypeList = new SelectList(list1, "LocalTypeID", "LocalTypeName");
            return View();
        }
        /// <summary>
        /// 查看入库详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StockInDetails(string id)
        {
            var Stock = db.WJ_StockIn.Find(id);
            return PartialView(Stock);
        }
        /// <summary>
        /// 货品统计
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductReport()
        {
            return View();
        }
        /// <summary>
        /// 出入库报表
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductInOutReport()
        {
            return View();
        }
        /// <summary>
        /// 入库报表
        /// </summary>
        /// <returns></returns>
        public ActionResult InStorageReport()
        {
            return View();
        }
        /// <summary>
        /// 出库报表
        /// </summary>
        /// <returns></returns>
        public ActionResult OutStorageReport()
        {
            return View();
        }
        /// <summary>
        /// 报损报表
        /// </summary>
        /// <returns></returns>
        public ActionResult BadReport()
        {
            return View();
        }
        /// <summary>
        /// 退货报表
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnReport()
        {
            return View();
        }
        /// <summary>
        /// 客户报表
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerReport()
        {
            return View();
        }
        /// <summary>
        /// 供应商报表
        /// </summary>
        /// <returns></returns>
        public ActionResult SupplierReport()
        {
            return View();
        }
        /// <summary>
        /// 台账记录
        /// </summary>
        /// <returns></returns>
        public ActionResult InventoryReport()
        {
            return View();
        }
    }
}
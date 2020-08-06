using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.OutStorage.Controllers
{
    public class ProductController : Controller
    {
        // GET: OutStorage/Product
        /// <summary>
        /// 出库管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Lists(int page, int limit, string StoONum)
        {
            Completion db = new Completion();
            var list = from x in db.WJ_StockOut
                       select new
                       {
                           x.StoONum,
                           StoOTypeName = x.WJ_StockOutType.StoOTypeName,
                           x.CreateTime,
                           SSName = x.WJ_StockStatus.SSName,
                           x.OrderNum,
                           CusName = x.BI_Customer.CusName,
                           x.Contact,
                           x.Phone,
                           UserName = x.Admin.UserName,
                           x.Remark
                       };
            if (!String.IsNullOrEmpty(StoONum))
            {
                list = list.Where(x => x.StoONum.Contains(StoONum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.StoONum,
                x.StoOTypeName,
                x.CreateTime,
                x.SSName,
                x.OrderNum,
                x.CusName,
                x.Contact,
                x.Phone,
                x.UserName,
                x.Remark
            });
            var info = new
            {
                count = total,
                code = 0,
                data = list1
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增出库
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
    }
}
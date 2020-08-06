using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Check.Controllers
{
    public class ProductController : Controller
    {
        // GET: Check/Product
        /// <summary>
        /// 盘点管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Lists(int page, int limit, string CheckNum)
        {
            Completion db = new Completion();
            var list = from x in db.WJ_Check
                       select new
                       {
                           x.CheckNum,
                           x.CreateTime,
                           x.CheckType,
                           SSName = x.WJ_StockStatus.SSName,
                           x.OrderNum,
                           UserName = x.Admin.UserName,
                           x.Remark
                       };
            if (!String.IsNullOrEmpty(CheckNum))
            {
                list = list.Where(x => x.CheckNum.Contains(CheckNum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.CheckNum,
                x.CreateTime,
                x.CheckType,
                x.SSName,
                x.OrderNum,
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
        /// 新增盘点
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
    }
}
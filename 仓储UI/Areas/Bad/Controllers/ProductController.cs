using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

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
        public ActionResult Lists(int page, int limit, string BreNum)
        {
            Completion db = new Completion();
            var list = from x in db.WJ_Breakage
                       select new
                       {
                           x.BreNum,
                           x.CreateTime,
                           BreTypeName=x.WJ_BreakageType.BreTypeName,
                           SSName = x.WJ_StockStatus.SSName,
                           x.OrderNum,
                           UserName = x.Admin.UserName,
                           x.Remark
                       };
            if (!String.IsNullOrEmpty(BreNum))
            {
                list = list.Where(x => x.BreNum.Contains(BreNum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.BreNum,
                x.CreateTime,
                x.BreTypeName,
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
        /// 新增报损
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
    }
}
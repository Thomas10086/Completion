using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Move.Controllers
{
    public class ProductController : Controller
    {
        // GET: Move/Product
        /// <summary>
        /// 移库管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Lists(int page, int limit, string MovNum)
        {
            Completion db = new Completion();
            var list = from x in db.WJ_Movement
                       select new
                       {
                           x.MovNum,
                           x.CreateTime,
                           MovTypeName = x.WJ_MovementType.MovTypeName,
                           SSName = x.WJ_StockStatus.SSName,
                           x.OrderNum,
                           UserName = x.Admin.UserName,
                           x.Remark
                       };
            if (!String.IsNullOrEmpty(MovNum))
            {
                list = list.Where(x => x.MovNum.Contains(MovNum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.MovNum).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.MovNum,
                x.CreateTime,
                x.MovTypeName,
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
        /// 新增移库
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
    }
}
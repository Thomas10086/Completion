using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Areas.InStorage.Controllers
{
    public class ProductController : Controller
    {
        // GET: InStorage/Product
        /// <summary>
        /// 入库管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Lists(int page, int limit,string StoINum)
        {
            Completion db = new Completion();
            var list = from x in db.WJ_StockIn
                       select new   
                       {
                           x.StoINum,
                           x.CreateTime,
                           StoITypeName = x.WJ_StockInType.StoITypeName,
                           SupName = x.BI_Supplier.SupName,
                           SSName = x.WJ_StockStatus.SSName,
                           x.ContactName,
                           x.OrderNum,
                           x.Phone,
                           UserName = x.Admin.UserName,
                           x.Remark
                       };
            if (!String.IsNullOrEmpty(StoINum))
            {
                list = list.Where(x => x.StoINum.Contains(StoINum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.StoINum,
                //CreateTime= x.CreateTime.ToString("yyyy-MM-dd hh:mm:ss"),
                x.CreateTime,
                x.StoITypeName,
                x.SupName,
                x.SSName,
                x.ContactName,
                x.OrderNum,
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
        /// 新增入库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            WJ_StockInTypeManager bll = new WJ_StockInTypeManager();
            List<WJ_StockInType> list=bll.GetAll();
            ViewBag.StoITypeNum = new SelectList(list,"StoITypeNum", "StoITypeName");
            WJ_StockInType info = new WJ_StockInType()
            {
                StoITypeNum = 0,
                StoITypeName = "--请选择--"
            };  
            list.Insert(0,info);
            return View();
        }
        [HttpPost]
        public ActionResult Adds(WJ_StockIn info)
        {
            WJ_StockInManager bll = new WJ_StockInManager();
            Completion db = new Completion();
            WJ_StockIn inf = db.WJ_StockIn.ToList().OrderBy(x => x.CreateTime).LastOrDefault();
            int StoINum = Convert.ToInt32(inf.StoITypeNum) + 1;
            string code = StoINum.ToString();
            var ss = bll.Add(info);
            if (ss)
            {
                return Json(ss, JsonRequestBehavior.DenyGet);
            }
            return Json(info, JsonRequestBehavior.DenyGet);
        }
        public ActionResult QueruyStatics(string StoINum)
        {
            Completion db = new Completion();
            var ss=db.WJ_StockIn.Find(StoINum);
            return Json(ss,JsonRequestBehavior.DenyGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Product.Controllers
{
    public class GoodsController : Controller
    {
        Completion db = new Completion();
        // GET: Product/Goods
        /// <summary>
        /// 产品管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list = db.BI_ProductCategory.ToList();
            var info = new BI_ProductCategory { CateNum = "0", CateName = "--请选择--" };
            list.Insert(0, info);
            ViewBag.ProductCategoryList = new SelectList(list, "CateNum", "CateName");
            return View();
        }
        /// <summary>
        /// 产品类别
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
    }
}
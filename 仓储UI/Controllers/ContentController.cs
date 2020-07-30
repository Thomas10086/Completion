using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;

namespace 仓储UI.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表格查询
        /// </summary>
        /// <returns></returns>
        public ActionResult QLeft(int page = 1, int limit = 10)
        {
            SysResourceManager bll = new SysResourceManager();
            var list = bll.GetAll();
            var list1 = list.Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.ResName,
            });
            var info = new
            {
                count = list.Count,
                code = 0,
                data = list1
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }
}
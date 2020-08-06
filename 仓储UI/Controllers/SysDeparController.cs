using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Controllers
{
    public class SysDeparController : Controller
    {
        // GET: SysDepart
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(SysDepart info)
        {
            SysDepartManager bll = new SysDepartManager();
            Completion db = new Completion();
            SysDepart inf = db.SysDepart.ToList().OrderBy(x => x.CreateTime).LastOrDefault();
            int DepartNum = Convert.ToInt32(inf.DepartNum) + 1;
            string code = DepartNum.ToString();
            SysDepart info1 = new SysDepart
            {
                DepartNum = code,
                DepartName =info.DepartName,
                IsDelete = 0,
                CreateTime = DateTime.Now,
                Remark = info.Remark
            };
            var ss = bll.Add(info1);
            if (ss)
            {
                return Json(ss, JsonRequestBehavior.DenyGet);
            }
            return Json(info, JsonRequestBehavior.DenyGet);
        }
    }
}
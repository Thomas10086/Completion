using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Controllers
{
    public class DeleteController : Controller
    {
        /// <summary>
        /// 员工删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdmintDelet(string id)
        {
            Completion db = new Completion();
            db.Admin.Find(id).IsDelete = 1;
            var bll = db.SaveChanges() > 0;
            return Json(bll, JsonRequestBehavior.DenyGet);
        }
        public ActionResult SysDeparDelet(string id)
        {
            Completion db = new Completion();
            db.SysDepart.Find(id).IsDelete = 1;
            var bll = db.SaveChanges() > 0;
            return Json(bll, JsonRequestBehavior.DenyGet);
        } 
        public ActionResult SysRoleDelet(string id)
        {
            Completion db = new Completion();
            db.SysRole.Find(id).IsDelete = 1;
            var bll = db.SaveChanges() > 0;
            return Json(bll, JsonRequestBehavior.DenyGet);
        }
        public ActionResult SysResourceDelet(string id)
        {
            Completion db = new Completion();
            db.SysResource.Find(id).IsDelete = 1;
            var bll = db.SaveChanges() > 0;
            return Json(bll, JsonRequestBehavior.DenyGet);
        }
    }
}
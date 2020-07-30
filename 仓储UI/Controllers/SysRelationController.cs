using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Controllers
{
    public class SysRelationController : Controller
    {
        // GET: SysRelation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QrueyALL()
        {
            return View();
        } 
        public ActionResult ajaxQrueyALL()
        {
            SysRelationManager bll = new SysRelationManager();
            var list=bll.GetAll();
            var list1 = list.Select(x=> new { 
            });
            return Json(list1,JsonRequestBehavior.AllowGet);
        }
    }
}
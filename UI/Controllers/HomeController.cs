using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AdminManager bll = new AdminManager();
            var list=bll.GetAll();
            var list1 = list.Select(
                x => new
                {
                    x.UserName,
                    x.PassWord,
                    x.SysRole.RoleName,
                    x.SysDepart.DepartName,
                    x.UserCode,
                    x.IsDelete,
                    x.Phone,
                    x.Email,
                    x.LoginCount
                });
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Left()
        {
            SysResourceManager bll = new SysResourceManager();
            var list = bll.QueryLeft();
            return View(list);
        } 
        public ActionResult QeruyName(string UserName)
        {
            AdminManager bll = new AdminManager();
            var list = bll.QeruyName(x=>x.UserName==UserName);
            var list1 = list.Select(x => new
            {
                x.UserName,
                x.PassWord,
                x.SysRole.RoleName,
                x.SysDepart.DepartName,
                x.UserCode,
                x.IsDelete,
                x.Phone,
                x.Email,
                x.LoginCount
            });
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
    }
}
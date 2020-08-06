using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;
using 仓储UI.Models;

namespace 仓储UI.Controllers
{
    public class AdmintController : Controller
    {
        AdminManager bll = new AdminManager();

        [HttpGet]
        public ActionResult Login() {
                Session.Clear();
                return View();
        }
        [HttpPost]
        public ActionResult Login(AdmitModel s)
        {
            if (ModelState.IsValid)
            {
                AdminManager bll = new AdminManager();
                var info = bll.GetObj(x => x.UserName == s.UserName && x.PassWord == s.PassWord);
                if (info != null)
                {
                    this.Session["ADMIN"] = info;
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("error", "密码错误");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            SysRoleManager bll = new SysRoleManager();
            var list = bll.GetAll();
            ViewBag.RoleNum = new SelectList(list, "RoleNum", "RoleName");
            SysDepartManager blls = new SysDepartManager();
            var list1 = blls.GetAll();
            ViewBag.DepartNum = new SelectList(list1, "DepartNum", "DepartName");
            return PartialView();
        }
        /// <summary>
        /// 新增员工 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddAdmin(Admin info)
        {
            if (ModelState.IsValid)
            {
                var ss = bll.Add(info);
                if (ss)
                {
                    return Redirect("/Home/QueryAllAdmin");
                }
                else
                {
                    return Content("新增失败");
                }
            }
            return View();
        }
    }
}
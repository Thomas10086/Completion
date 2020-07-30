using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;
using 仓储UI.App_Start;

namespace 仓储UI.Controllers
{
    
    public class HomeController : Controller
    {
        [MyFilter]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 员工管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserList()
        {
            return View();
        }
        public ActionResult QueryAllAdmins(int page=1,int limit=10)
        {
            AdminManager bll = new AdminManager();
            var list = bll.GetAll();
            var list1 = list.Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.UserName,
                x.UserCode,
                x.ZName,
                x.Email,
                x.Phone,
                x.Remark,
                RoleName = x.SysRole.RoleName,
                DepartName = x.SysDepart.DepartName,
                x.IsDelete,
                x.LoginCount
            });
            var info = new
            {
                count = list.Count,
                code = 0,
                data = list1
            };

            return Json(info, JsonRequestBehavior.AllowGet);
        }
       
        /// <summary>
        ///左侧导航栏 
        /// </summary>
        /// <returns></returns>
        public ActionResult Left()
        {
            SysResourceManager bll = new SysResourceManager();
            var info = this.Session["ADMIN"] as Admin;

            var list = bll.QueryLeft();
            return PartialView(list);
        }
        /// <summary>
        /// 员工管理模糊查询
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult QeruyName()
        {
            return View();
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult QeruyNames(Admin info)
        {
            AdminManager bll = new AdminManager();
            Completion c = new Completion();
            var li = from ss in c.Admin where ss.UserName.Contains(info.UserName) select ss;
            var list1 = li.Select(x => new
            {
                x.UserName,
                x.RoleNum,
                x.PassWord,
                RoleName = x.SysRole.RoleName,
                DepartName = x.SysDepart.DepartName,
                x.LoginCount,
                x.IsDelete,
                x.Email,
                x.Phone,
                x.ZName
            });
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 角色管理
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult RoleList(Admin info)
        {
            return View();
        }
        /// <summary>
        /// 部门管理
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult DepartList(Admin info)
        {
            return View();
        }
        public ActionResult Add()
        {
            return Redirect("/Admin/AddAdmin");
        }
    }
}
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;
using 仓储UI.App_Start;
using 仓储UI.Models;

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
        public ActionResult UserLists(int page, int limit, string UserName,string UserCode)
        {
            Completion db = new Completion();
            var list = from ss in db.Admin
                       where ss.IsDelete==0
                       select new
                       {
                           ss.UserName,
                           ss.UserCode,
                           ss.ZName,
                           ss.Email,
                           ss.Phone,
                           ss.Remark,
                           RoleName = ss.SysRole.RoleName,
                           DepartName = ss.SysDepart.DepartName,
                           ss.IsDelete,
                           ss.LoginCount,
                           ss.CreateTime
                       };
            if (!String.IsNullOrEmpty(UserName))
            {
                list = list.Where(x => x.UserName.Contains(UserName));
            }
            if (!String.IsNullOrEmpty(UserCode)) {
                list = list.Where(x => x.UserCode.Contains(UserCode));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.UserName,
                x.UserCode,
                x.ZName,
                x.Email,
                x.Phone,
                x.Remark,
                x.RoleName,
                x.DepartName,
                x.IsDelete,
                x.LoginCount
            });
            var info = new
            {
                count = total,
                code = 0,
                data = list1
            };

            return Json(info, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            List<SysRole> list = new SysRoleManager().GetAll();
            List<SysDepart> list1 = new SysDepartManager().GetAll();
            SysRole info = new SysRole()
            {
                RoleNum = "0",
                RoleName = "--请选择--"
            };
            list.Insert(0, info);
            SysDepart info1 = new SysDepart()
            {
                DepartNum = "0",
                DepartName = "--请选择--"
            };
            list1.Insert(0, info1);
            ViewBag.RoleNum = new SelectList(list, "RoleNum", "RoleName");
            ViewBag.DepartNum = new SelectList(list1, "DepartNum", "DepartName");
            return PartialView();
        }
        /// <summary>
        /// 新增员工 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(AdminModelel info)
        {
            if (ModelState.IsValid)
            {
                AdminManager bll = new AdminManager();
                Completion db = new Completion();
                Admin inf = db.Admin.ToList().OrderBy(x=>x.CreateTime).LastOrDefault();
                int UserCode =Convert.ToInt32(inf.UserCode)+1;
                string code = UserCode.ToString();
                Admin info1 = new Admin
                {
                    UserCode = code,
                    ZName=info.ZName,
                    IsDelete=0,
                    LoginCount=0,
                    CreateTime = DateTime.Now,
                    UpdateTime=DateTime.Now,
                    UserName = info.UserName,
                    PassWord = info.PassWord,
                    Email = info.Email,
                    Phone = info.Phone,
                    RoleNum = info.RoleNum,
                    DepartNum = info.DepartNum,
                    Remark=info.Remark
                };
                var ss = bll.Add(info1);
                if (ss)
                {
                    return Json(ss, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    ModelState.AddModelError("error", "登录失败");
                }
                return Json(ss, JsonRequestBehavior.DenyGet);
            }
            return Json(info, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        ///左侧导航栏 
        /// </summary>
        /// <returns></returns>
        public ActionResult Left()
        {
            SysResourceManager bll = new SysResourceManager();
            var list = bll.QueryLeft();
            return PartialView(list);
        }
        public ActionResult RoleList()
        {
            return View();
        }
            /// <summary>
            /// 角色管理
            /// </summary>
            /// <param name="info"></param>
            /// <returns></returns>
        public ActionResult RoleLists(int page,int limit,string RoleName)
        {
            Completion db = new Completion();
            var list = from ss in db.SysRole
                       where ss.IsDelete==0
                       select new
                       {
                           ss.RoleNum,
                           ss.RoleName,
                           CreateTime = ss.CreateTime,
                           ss.IsDelete,
                           ss.Remark
                       };
            if (!String.IsNullOrEmpty(RoleName))
            {
                list = list.Where(x => x.RoleName.Contains(RoleName));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.RoleNum,
                x.RoleName,
                //CreateTime=Convert.ToDateTime(x.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"),
                //CreateTime = x.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                x.CreateTime,
                x.IsDelete,
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
        /// 部门管理
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult DepartList()
        {
            return View();
        }
        public ActionResult DepartLists(int page, int limit,string DepartName)
        {
            Completion db = new Completion();
            var list = from ss in db.SysDepart
                       where ss.IsDelete == 0
                       select new
                       {
                           ss.DepartNum,
                           ss.DepartName,
                           ss.CreateTime,
                           ss.IsDelete,
                           ss.Remark
                       };
            if (!String.IsNullOrEmpty(DepartName))
            {
                list = list.Where(x => x.DepartName.Contains(DepartName));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.DepartNum,
                x.DepartName,
                CreateTime=x.CreateTime.ToString(),
                x.IsDelete,
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
    }
}
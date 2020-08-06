using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        /// <summary>
        /// 员工修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateAdmin(string id)
        {
            List<SysRole> list = new SysRoleManager().GetAll();
            List<SysDepart> list1 = new SysDepartManager().GetAll();
            AdminManager bll = new AdminManager();
            var ss=bll.GetByPK(id);
            ViewBag.RoleNum = new SelectList(list, "RoleNum", "RoleName", ss.RoleNum);
            ViewBag.DepartNum = new SelectList(list1, "DepartNum", "DepartName",ss.DepartNum);
            return PartialView(ss);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin info)
        {
            Completion db = new Completion();
            info.IsDelete = 0;
            info.CreateTime = db.Admin.Find(info.UserCode).CreateTime;
            var ss = db.Admin.Find(info.UserCode);
            ss.UserName = info.UserName;
            ss.ZName = info.ZName;
            ss.RoleNum = info.RoleNum;
            ss.Remark = info.Remark;
            ss.Phone = info.Phone;
            ss.DepartNum = info.DepartNum;
            var bl = db.SaveChanges() > 0;
            return Json(bl, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 部门修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateSysDepar(string id)
        {
            SysDepartManager bll = new SysDepartManager();
            var ss=bll.GetByPK(id);
            return PartialView(ss);
        }
        [HttpPost]
        public ActionResult UpdateSysDepar(SysDepart info)
        {
            Completion db = new Completion();
            info.IsDelete = 0;
            info.CreateTime = db.SysDepart.Find(info.DepartNum).CreateTime;
            var ss = db.SysDepart.Find(info.DepartNum);
            ss.DepartNum = info.DepartNum;
            ss.Remark=info.Remark;
            ss.DepartName = info.DepartName;
            var bl = db.SaveChanges() > 0;
            return Json(bl, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateSysRole(string id)
        {
            SysRoleManager bll = new SysRoleManager();
            var ss= bll.GetByPK(id);
            return PartialView(ss);
        }
        [HttpPost]
        public ActionResult UpdateSysRole(SysRole info)
        {
            Completion db = new Completion();
            info.IsDelete = 0;
            info.CreateTime = db.SysRole.Find(info.RoleNum).CreateTime;
            var ss = db.SysRole.Find(info.RoleNum);
            ss.RoleNum = info.RoleNum;
            ss.RoleName = info.RoleName;
            ss.Remark = info.Remark;
            var bl = db.SaveChanges() > 0;
            return Json(bl, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 菜单修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateSysResource(string id)
        {
            SysResourceManager bll = new SysResourceManager();
            var ss=bll.GetByPK(id);
            return PartialView(ss);
        }
        [HttpPost]
        public ActionResult UpdateSysResource(SysResource info)
        {
            Completion db = new Completion();
            info.IsDelete = 0;
            info.CreateTime = db.SysResource.Find(info.ResNum).CreateTime;
            var ss = db.SysResource.Find(info.ResNum);
            ss.ResNum = info.ResNum;
            ss.ResName = info.ResName;
            ss.Remark = info.Remark;
            ss.Url = info.Url;
            var bl = db.SaveChanges() > 0;
            return Json(bl, JsonRequestBehavior.DenyGet);
        }
    }
}
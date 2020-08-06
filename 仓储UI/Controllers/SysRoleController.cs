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
    public class SysRoleController : Controller
    {
        // GET: SysRole
        /// <summary>
        /// 角色新增
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(SysRole info)
        {
            SysRoleManager bll = new SysRoleManager();
            Completion db = new Completion();
            SysRole inf = db.SysRole.ToList().OrderBy(x => x.CreateTime).LastOrDefault();
            int RoleNum = Convert.ToInt32(inf.RoleNum) + 1;
            string code = RoleNum.ToString();
            SysRole info1 = new SysRole
            {
                RoleNum = code,
                RoleName=info.RoleName,
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
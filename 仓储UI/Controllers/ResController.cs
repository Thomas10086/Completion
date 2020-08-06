using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Controllers
{
    public class ResController : Controller
    {
        // GET: Res
        /// <summary>
        /// 菜单管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Indexs(int page, int limit, string ResNum)
        {
            Completion db = new Completion();
            var list = from x in db.SysResource
                       where x.IsDelete == 0
                       select new
                       {
                           x.ResNum,
                           x.ResName,
                           x.ParentNum,
                           x.Url,
                           x.CreateTime,
                           x.IsDelete,
                           x.Remark
                       };
            if (!String.IsNullOrEmpty(ResNum))
            {
                list = list.Where(x => x.ResNum.Contains(ResNum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.ResNum,
                x.ResName,
                x.ParentNum,
                x.Url,
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
        /// 菜单管理新增
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            List<SysResource> list = new SysResourceManager().GetAll();
            SysResource info = new SysResource()
            {
                ResNum = "0",
                ResName = "--请选择--"
            };
            list.Insert(0, info);
            ViewBag.ResourceList = new SelectList(list, "ResNum", "ResName");
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(SysResource info)
        {
            SysResourceManager bll = new SysResourceManager();
            Completion db = new Completion();
            SysResource inf = db.SysResource.ToList().OrderBy(x => x.CreateTime).LastOrDefault();
            int ResNum = Convert.ToInt32(inf.ResNum) + 1;
            string code = ResNum.ToString();
            SysResource info1 = new SysResource
            {
                ResNum = code,
                ResName = info.ResName,
                Url = info.Url,
                IsDelete = 0,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                Remark = info.Remark
            };
            var ss = bll.Add(info1);
            if (ss)
            {
                return Json(ss, JsonRequestBehavior.DenyGet);
            }
            return Json(info, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 权限管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Power()
        {
            List<Admin> bll = new AdminManager().Where(x => x.UserCode != "000003");
            Admin info = new Admin()
            {
                UserCode = "0",
                UserName = "--请选择--"
            };
            bll.Insert(0, info);
            ViewBag.UserCode = new SelectList(bll, "UserCode", "UserName");
            return View();
        }
        public ActionResult Powers(int page,int limit)
        {
                Completion db = new Completion();
                string RoleNum = "SA_00000";
                var list = db.SysRelation.ToList().Where(x => x.RoleNum == RoleNum);
                int total = list.Count();
                var list1 = list.Select(x => new
                {
                    x.ResNum,
                    ResName = x.SysResource.ResName
                });
                
                var info = new
                {
                    count = total,
                    code = 0,
                    data = list1
                };
                return Json(info, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SysRelationDelete(int id)
        {
            Completion db = new Completion();
            db.SysRelation.Find(id);
            var bll = db.SaveChanges() > 0;
            return Json(bll, JsonRequestBehavior.DenyGet);
        }

        public ActionResult ShowIndex()
        {
            return View();
        }
        /// <summary>
        /// 穿梭框
        /// </summary>
        /// <returns></returns>
        public ActionResult Show(SysResource ss)
        {
            string RoleNum = "SA_00000";    
            List<SysRelation> list = new SysRelationManager().Where(x=>x.RoleNum==RoleNum);
            List<SysResource> list1 = new SysResourceManager().Where(x=>x.ResName==ss.ResName);
            foreach (var item in list)
            {
                list1.Remove(item.SysResource);
            }
            List<string> SysRelatiolist = new List<string>();
            foreach (var item in list)
            {
                SysRelatiolist.Add(item.ResNum.ToString());
            }
            var SysResourceList = list1.Select(x=> new { 
                value=x.ResNum,
                title = x.ResName
            });
            var info = new
            {
                SysResource = SysResourceList,
                SysRelatio = SysRelatiolist
            };
            return Json("",JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ActionResult SysRelationAdd(List<SysRelation> list)
        {
            return Json("",JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ActionResult SysRelationDel(List<SysRelation> list)
        {
            foreach (var item in list)
            {
                SysRelation SList = new SysRelationManager().Where(x => x.ResNum == item.ResNum && x.RoleNum == item.RoleNum).FirstOrDefault();
                bool i = new SysRelationManager().Delete(SList.ResNum);

            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}
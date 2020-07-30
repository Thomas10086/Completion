using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.Areas.Storage.Controllers
{
    public class LocationController : Controller
    {
        Completion db = new Completion();
        /// <summary>
        /// 库位管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var list = db.BI_Storage.ToList();
            var info = new BI_Storage { StorageNum = "0", StorageName = "--请选择仓库--" };
            list.Insert(0, info);
            ViewBag.StorageList = new SelectList(list, "StorageNum", "StorageName");
            var list1 = db.BI_LocaType.ToList();
            var info1 = new BI_LocaType { LocalTypeID = 0, LocalTypeName = "--请选择--" };
            list1.Insert(0, info1);
            ViewBag.LocalTypeList = new SelectList(list1, "LocalTypeID", "LocalTypeName");
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            var list = db.BI_Storage.ToList();
            var info = new BI_Storage { StorageNum = "0", StorageName = "--请选择仓库--" };
            list.Insert(0, info);
            ViewBag.StorageList = new SelectList(list, "StorageNum", "StorageName");
            var list1 = db.BI_LocaType.ToList();
            var info1 = new BI_LocaType { LocalTypeID = 0, LocalTypeName = "--请选择库位类型--" };
            list1.Insert(0, info1);
            ViewBag.LocalTypeList = new SelectList(list1, "LocalTypeID", "LocalTypeName");
            var list2 = new ArrayList();
            var info2 = new BI_Storage { StorageNum = "2", StorageName = "--请选择--" };
            var info3 = new BI_Storage { StorageNum = "0", StorageName = "是" };
            var info4 = new BI_Storage { StorageNum = "1", StorageName = "否" };
            list2.Add(info2);
            list2.Add(info3);
            list2.Add(info4);
            ViewBag.IsDefault = new SelectList(list2, "StorageNum", "StorageName");
            return PartialView();
        }
        [HttpGet]
        public ActionResult Upd(string id)
        {
            var info = db.BI_Location.Find(id);
            var list = db.BI_Storage.ToList();
            var list1 = db.BI_LocaType.ToList();
            var list2 = new ArrayList();
            var info3 = new BI_Storage { StorageNum = "0", StorageName = "是" };
            var info4 = new BI_Storage { StorageNum = "1", StorageName = "否" };
            list2.Add(info3);
            list2.Add(info4);
            ViewBag.StorageList = new SelectList(list, "StorageNum", "StorageName",info.StorageNum);
            ViewBag.LocalTypeList = new SelectList(list1, "LocalTypeID", "LocalTypeName",info.LocalTypeID);
            ViewBag.IsDefault = new SelectList(list2, "StorageNum", "StorageName");
           
            return PartialView(info);
        }
    }
}
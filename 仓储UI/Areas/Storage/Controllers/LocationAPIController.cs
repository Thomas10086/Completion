using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Areas.Storage.Controllers
{
    public class LocationAPIController : ApiController
    {
        Completion db = new Completion();
        //Result res = null;
        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult LocationList(int page, int limit, string LocalName, int? LocalTypeID, string StorageNum=null)
        {
            var list = from s in db.BI_Location
                       where s.IsDelete == 0
                       select new
                       {
                           s.LocalNum,
                           s.LocalName,
                           s.StorageNum,
                           s.BI_Storage.StorageName,
                           s.LocalTypeID,
                           s.BI_LocaType.LocalTypeName,
                           IsDefault=s.IsDefault==0? "是":"否",
                           s.CreateTime
                       };
            if (!string.IsNullOrEmpty(LocalName))
            {
                list = list.Where(x => x.LocalName.Contains(LocalName) || x.LocalNum.Contains(LocalName));
            }
            if (StorageNum!="0")
            {
                list = list.Where(x => x.StorageNum == StorageNum);
            }
            if (LocalTypeID!=0)
            {
                list = list.Where(x => x.LocalTypeID == LocalTypeID);
            }
            var total = list.Count();
            list = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit);
            ArrayList arrayList = new ArrayList();
            foreach (var i in list)
            {
                arrayList.Add(new { 
                    i.LocalNum,
                    i.LocalName,
                    i.StorageName,
                    i.LocalTypeName,
                    i.IsDefault,
                    CreateTime=i.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
                return Json(new {code=0,msg="", count=total,data=arrayList});
        }
        [HttpPost]
        public IHttpActionResult Add(BI_Location info)
        {
            string info1 = db.BI_Location.ToList().OrderBy(x=>x.CreateTime).LastOrDefault().LocalNum;
            string localNum = info1.Substring(0,8)+(Convert.ToInt32(info1.Substring(6,3)) + 1).ToString();
            info.CreateTime = DateTime.Now;
            info.LocalNum = localNum;
            info.IsDelete = 0;
            var bl = new BI_LocationManager().Add(info);
            return Json(bl);
        }
        [HttpPost]
        public IHttpActionResult Upd(BI_Location info)
        {
            info.IsDelete = 0;
            info.CreateTime = db.BI_Location.Find(info.LocalNum).CreateTime;
            var bl = new BI_LocationManager().Update(info);
            return Json(bl);
        }
        [HttpPost]
        public IHttpActionResult del(string id)
        {
            db.BI_Location.Find(id).IsDelete=1;
            var bl = db.SaveChanges() > 0;
            return Json(bl);
        }
    }
}
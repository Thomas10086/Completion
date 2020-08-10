using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Areas.Storage.Controllers
{
    public class MeasureAPIController : ApiController
    {
        Completion db = new Completion();
        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult MeasureList(int page, int limit,string MeasureName)
        {
            var list = from s in db.BI_Measure
                       select new
                       {
                           s.MeasureNum,
                           s.MeasureName
                       };
            if (!string.IsNullOrEmpty(MeasureName))
            {
                list = list.Where(x => x.MeasureName.Contains(MeasureName)||x.MeasureNum.Contains(MeasureName));
            }
            var total = list.Count();
            var MeasureList = list.OrderByDescending(x => x.MeasureNum).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.MeasureNum,
                x.MeasureName
            });
            return Json(new {code=0,count=total,data=MeasureList });
        }
        [HttpPost]
        public IHttpActionResult Add(BI_Measure info)
        {
            string info1 = db.BI_Measure.ToList().OrderBy(x => x.MeasureNum).LastOrDefault().MeasureNum;
            info.MeasureNum = info1.Substring(0, 4) + (Convert.ToInt32(info1.Substring(4, 2)) + 1).ToString();
            db.BI_Measure.Add(info);
            var bl = db.SaveChanges() > 0;
            return Json(bl);
        }
        [HttpPost]
        public IHttpActionResult Upd(BI_Measure info)
        {
            var bl= new BI_MeasureManager().Update(info);
            return Json(bl);
        }
        [HttpPost]
        public IHttpActionResult del(string id)
        {
            db.BI_Measure.Remove(db.BI_Measure.Find(id));
            var bl = db.SaveChanges() > 0;
            return Json(bl);
        }
        
    }
}
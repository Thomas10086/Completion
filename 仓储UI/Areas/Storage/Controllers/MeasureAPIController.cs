using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

    }
}
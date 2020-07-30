using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 仓储Model;

namespace 仓储UI.Areas.Client.Controllers
{
    public class CustomerAPIController : ApiController
    {
        Completion db = new Completion();
        [HttpGet]
        public IHttpActionResult CustomerList(int page, int limit, string CusName)
        {
            var list = from x in db.BI_Customer
                       select new
                       {
                           x.CusNum,
                           x.CusName,
                           x.Phone,
                           x.Fax,
                           x.Email,
                           x.CreateTime
                       };
            if (!string.IsNullOrEmpty(CusName))
            {
                list = list.Where(x => x.CusName.Contains(CusName) || x.CusNum.Contains(CusName));
            }
            var total = list.Count();
            var list1 = list.OrderByDescending(x => x.CusNum).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.CusNum,
                x.CusName,
                x.Phone,
                x.Fax,
                x.Email,
                x.CreateTime
            });
            return Json(new { code = 0, count = total, data = list1 });
        }

    }
}
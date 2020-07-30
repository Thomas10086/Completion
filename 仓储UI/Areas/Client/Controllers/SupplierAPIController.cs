using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 仓储Model;

namespace 仓储UI.Areas.Client.Controllers
{
    public class SupplierAPIController : ApiController
    {
        Completion db = new Completion();
        [HttpGet]
        public IHttpActionResult SupplierList(int page, int limit, string SupName)
        {
            var list = from x in db.BI_Supplier
                       select new
                       {
                           x.SupNum,
                           x.SupName,
                           x.SupTypeID,
                           x.BI_SupType.SupTypeName,
                           x.Phone,
                           x.Fax,
                           x.Email,
                           x.ContactName,
                           x.Address,
                           x.Description
                       };
            if (!string.IsNullOrEmpty(SupName))
            {
                list = list.Where(x => x.SupName.Contains(SupName) || x.SupNum.Contains(SupName));
            }
            var total = list.Count();
            var list1 = list.OrderByDescending(x => x.SupNum).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.SupNum,
                x.SupName,
                x.SupTypeName,
                x.Phone,
                x.Fax,
                x.Email,
                x.ContactName,
                x.Address,
                x.Description
            });
            return Json(new { code = 0, count = total, data = list1 });
        }

       
    }
}
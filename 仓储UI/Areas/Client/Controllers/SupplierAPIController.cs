using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 仓储BLL;
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
                       where x.IsDelete==0
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

        [HttpPost]
        public IHttpActionResult Add(BI_Supplier info)
        {
            string info1 = db.BI_Supplier.ToList().OrderBy(x => x.CreateTime).LastOrDefault().SupNum;

            info.SupNum = info1.Substring(0, 4) + (Convert.ToInt32(info1.Substring(4, 2)) + 1).ToString();
            info.CreateTime = DateTime.Now;
            info.IsDelete = 0;
            var bl = new BI_SupplierManager().Add(info);
            return Json(bl);
        }

        [HttpPost]
        public IHttpActionResult del(string id)
        {
            db.BI_Supplier.Find(id).IsDelete = 1;
            var bl = db.SaveChanges() > 0;
            return Json(bl);
        }

        [HttpPost]
        public IHttpActionResult Upd(BI_Supplier info)
        {
            info.IsDelete = 0;
            info.CreateTime = db.BI_Supplier.Find(info.SupNum).CreateTime;
            var bl = new BI_SupplierManager().Update(info);
            return Json(bl);
        }
    }
}
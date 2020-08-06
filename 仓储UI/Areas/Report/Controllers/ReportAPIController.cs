using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 仓储Model;

namespace 仓储UI.Areas.Report.Controllers
{
    public class ReportAPIController : ApiController
    {
        Completion db = new Completion();
        [HttpGet]
        public IHttpActionResult ReportList(int page, int limit, string LocalName, int LocalTypeID, string ProductName)
        {
            var list = from x in db.BI_LocalProduct
                       select new
                       {
                           LocalName=x.BI_Location.LocalName
                          ,x.LocalNum
                          ,x.BI_Location.LocalTypeID
                          ,LocalTypeName=x.BI_Location.BI_LocaType.LocalTypeName
                          ,x.ProductLot
                          ,CateName=x.BI_Product.BI_ProductCategory.CateName
                          ,Size=x.BI_Product.Size
                          ,MaxNum=x.BI_Product.MaxNum
                          ,MinNum=x.BI_Product.MinNum
                          ,x.SnNum
                          ,x.BarCode
                          ,StorageName=x.BI_Location.BI_Storage.StorageName
                          ,ProductName=x.BI_Product.ProductName
                          ,x.CreateTime
                          ,x.Num
                       };
            if (!string.IsNullOrEmpty(LocalName))
            {
                list = list.Where(x => x.LocalName.Contains(LocalName) || x.LocalNum.Contains(LocalName));
            }
            if (!string.IsNullOrEmpty(ProductName))
            {
                list = list.Where(x => x.ProductName.Contains(ProductName)||x.SnNum.Contains(ProductName) ||x.BarCode.Contains(ProductName));
            }
            if (LocalTypeID != 0)
            {
                list = list.Where(x => x.LocalTypeID == LocalTypeID);
            }
            var total = list.Count();
            var LocalProductlist = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.LocalName
                ,x.LocalTypeName
                ,x.SnNum
                ,x.BarCode
                ,x.ProductName
                ,x.CateName
                ,x.Size
                ,x.MaxNum
                ,x.MinNum
                ,x.Num
            });
            return Json(new { code = 0, msg = "联系管理员吧", count = total, data = LocalProductlist });
        }
    }
}
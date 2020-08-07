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

        [HttpGet]
        public IHttpActionResult ProductList(int page, int limit, string Product)
        {
            var list = from x in db.BI_Product
                       select new
                       {
                           x.SnNum
                           ,x.BarCode
                           ,x.ProductName
                           ,CateName=x.BI_ProductCategory.CateName
                           ,x.MaxNum
                           ,x.MinNum
                           ,x.Size
                           ,x.CreateTime
                           ,
                           Num = (from s in db.BI_LocalProduct
                                  where (s.SnNum==x.SnNum) && (s.BarCode==x.BarCode)
                                select s.Num).Sum()
                           ,InCount= (from s in db.WJ_StockInDetails
                                      where (s.SnNum == x.SnNum) && (s.BarCode == x.BarCode)
                                      select s.Num).Sum()
                           ,
                           OutCount= (from s in db.WJ_StockOutDetails
                                      where (s.SnNum == x.SnNum) && (s.BarCode == x.BarCode)
                                      select s.Num).Sum()
                           ,
                           BreCount= (from s in db.WJ_BreakageDetails
                                      where (s.SnNum == x.SnNum) && (s.BarCode == x.BarCode)
                                      select s.Num).Sum()
                       };
            if (!string.IsNullOrEmpty(Product))
            {
                list = list.Where(x => x.ProductName.Contains(Product) || x.SnNum.Contains(Product) || x.BarCode.Contains(Product));
            }
            var total = list.Count();
            var ProductList = list.OrderBy(x=>x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.SnNum,
                x.BarCode,
                x.ProductName,
                x.CateName,
                x.MaxNum,
                x.MinNum,
                x.Size,
                Num=x.Num == null ? 0 : x.Num,
                InCount=x.InCount == null ? 0 : x.InCount,
                OutCount=x.OutCount == null ? 0 : x.OutCount,
                BreCount=x.BreCount==null? 0: x.BreCount
            });

            return Json(new { code = 0, msg = "联系管理员吧", count = total, data = ProductList });
        }
    }
}
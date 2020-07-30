using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 仓储Model;

namespace 仓储UI.Areas.Product.Controllers
{
    public class GoodsAPIController : ApiController
    {
        Completion db = new Completion();
        // GET api/<controller>
        /// <summary>
        /// get所有产品
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="ProductName"></param>
        /// <param name="CateNum"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult ProductList(int page, int limit, string ProductName, string CateNum)
        {
            var list = from s in db.BI_Product
                       select new
                       {
                           s.SnNum,
                           s.BarCode,
                           s.ProductName,
                           s.MaxNum,
                           s.MinNum,
                           s.InPrice,
                           s.OutPrice,
                           s.Size,
                           s.MeasureNum,
                           s.BI_Measure.MeasureName,
                           s.CateNum,
                           s.BI_ProductCategory.CateName,
                           s.Remark
                       };
            if (!string.IsNullOrEmpty(ProductName))
            {
                list = list.Where(x => x.ProductName.Contains(ProductName)||x.SnNum.Contains(ProductName)||x.BarCode.Contains(ProductName));
            }
            if (CateNum!="0")
            {
                list = list.Where(x => x.CateNum == CateNum);
            }
            var total = list.Count();
            var list1 = list.OrderByDescending(x => x.SnNum).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.SnNum,
                x.BarCode,
                x.ProductName,
                x.MaxNum,
                x.MinNum,
                x.InPrice,
                x.OutPrice,
                x.Size,
                x.MeasureName,
                x.CateName,
                x.Remark
            });
            return Json(new {code=0,count=total,data=list1 });
        }
        /// <summary>
        /// get产品类别
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="CateName"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult ProductCategoryList(int page, int limit, string CateName)
        {
            var list = from x in db.BI_ProductCategory
                       where x.IsDelete==0
                       select new
                       {
                           x.CateNum,
                           x.CateName,
                           UserName=x.Admin.UserName,
                           x.CreateTime,
                           x.Remark
                       };
            if (!string.IsNullOrEmpty(CateName))
            {
                list = list.Where(x => x.CateName.Contains(CateName) || x.CateNum.Contains(CateName));
            }
            var total = list.Count();
            var list1 = list.OrderByDescending(x => x.CateNum).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.CateNum,
                x.CateName,
                x.UserName,
                x.CreateTime,
                x.Remark
            });
            return Json(new { code = 0, count = total, data = list1 });
        }

    }
}
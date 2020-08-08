using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储BLL;
using 仓储Model;

namespace 仓储UI.Areas.InStorage.Controllers
{
    public class ProductController : Controller
    {
        Completion db = new Completion();
        // GET: InStorage/Product
        /// <summary>
        /// 入库管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Lists(int page,  int limit,string StoINum,int SSNum)
        {
            Completion db = new Completion();
            var list = from x in db.WJ_StockIn
                       select new
                       {
                           x.StoINum,
                           x.CreateTime,
                           StoITypeName = x.WJ_StockInType.StoITypeName,
                           SupName = x.BI_Supplier.SupName,
                           x.ContactName,
                           x.OrderNum,
                           x.Phone,
                           UserName = x.Admin.UserName,
                           x.Remark,
                           x.SSNum,
                           SSName = x.WJ_StockStatus.SSName,
                       };
            if (!string.IsNullOrEmpty(StoINum))
            {
                list = list.Where(x => x.StoINum.Contains(StoINum));
            }
            if (SSNum!=3)
            {
                list = list.Where(x => x.SSNum == SSNum);
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.StoINum,
                //CreateTime= Convert.ToDateTime(x.CreateTime).ToString("yyyy-MM-dd hh:mm:ss"),
                x.CreateTime,
                x.StoITypeName,
                x.SupName,
                x.SSName,
                x.ContactName,
                x.OrderNum,
                x.Phone,
                x.UserName,
                x.Remark
            });
            var info = new
            {
                count = total,
                code = 0,
                data = list1
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增入库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            WJ_StockInTypeManager bll = new WJ_StockInTypeManager();
            List<WJ_StockInType> list = bll.GetAll();
            ViewBag.StoITypeNum = new SelectList(list, "StoITypeNum", "StoITypeName");
            WJ_StockInType info = new WJ_StockInType()
            {
                StoITypeNum = 0,
                StoITypeName = "--请选择--"
            };
            list.Insert(0, info);
            return View();
        }
        [HttpPost]
        public ActionResult Add(WJ_StockIn info)
        {
            WJ_StockInManager bll = new WJ_StockInManager();
            Completion db = new Completion();
            WJ_StockIn inf = db.WJ_StockIn.ToList().OrderBy(x => x.CreateTime).LastOrDefault();
            int StoINum = Convert.ToInt32(inf.StoINum) + 1;
            string code = StoINum.ToString();
            WJ_StockIn info1 = new WJ_StockIn
            {
                StoINum = code,
                StoITypeNum = info.StoITypeNum,
                OrderNum = info.OrderNum,
                UserCode=info.UserCode,
                SupNum = info.BI_Supplier.SupNum,
                ContactName = info.BI_Supplier.ContactName,
                CreateTime = info.CreateTime,
                Remark=info.Remark
            };
            var ss = bll.Add(info1);
            if (ss)
            {
                return Json(ss, JsonRequestBehavior.DenyGet);
            }
            return Json(info, JsonRequestBehavior.DenyGet);
        }
        public ActionResult QueruyStatics(string StoINum)
        {
            Completion db = new Completion();
            var ss=db.WJ_StockIn.Find(StoINum);
            return Json(ss,JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 双击事件供应商id
        /// </summary>
        /// <returns></returns>
        public ActionResult WJ_StockIns()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult WJ_StockInQuery(int page, int limit,string SupNum)
        {
            Completion db = new Completion();
            var ss=db.BI_Supplier.ToList();
            var list = from x in db.BI_Supplier
                       where x.IsDelete == 0
                       select new
                       {
                           x.SupNum,
                           x.SupName,
                           SupTypeName = x.BI_SupType.SupTypeName,
                           x.Phone,
                           x.Fax,
                           x.Email,
                           x.ContactName,
                           x.Address,
                           x.CreateTime,
                           x.Description
                       };
            if (!String.IsNullOrEmpty(SupNum))
            {
                list = list.Where(x => x.SupNum.Contains(SupNum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
                    {
                        x.SupNum,
                        x.SupName,
                        x.SupTypeName,
                        x.Phone,
                        x.Fax,
                        x.Email,
                        x.ContactName,
                        x.Address,
                        x.CreateTime,
                        x.Description
                    });
            var info = new
            {
                count = total,
                code = 0,
                data = list1
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品点击事件
        /// </summary>
        /// <returns></returns>
        public ActionResult BI_Products()
        {
            return PartialView();
        }
        public ActionResult BI_ProductQeruy()
        {
            return Json("",JsonRequestBehavior.DenyGet); 
        }
        /// <summary>
        /// 产品事件新增
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBI_Products()
        {
            List< BI_ProductCategory > bll= new BI_ProductCategoryManager().GetAll();
            ViewBag.BI_ProductCategoryList = new SelectList(bll, "CateNum","CateName");
            BI_ProductCategory info = new BI_ProductCategory
            {
                CateNum="0",
                CateName="--请选择--"
            };
            return PartialView();
        }
        public ActionResult AddBI_ProductQeruy(int page, int limit, string BarCode,string ProductName)
        {
            var ss = db.BI_Product.ToList();
            var list = from x in db.BI_Product
                       select new
                       {
                           x.BarCode,
                           x.ProductName,
                           MeasureName=x.BI_Measure.MeasureName,
                           CateName=x.BI_ProductCategory.CateName,
                           x.Size,
                           x.Remark,
                           x.InPrice,
                           x.CreateTime
                        };
            if (!String.IsNullOrEmpty(BarCode))
            {
                list = list.Where(x => x.BarCode.Contains(BarCode));
            }
            if (!String.IsNullOrEmpty(ProductName))
            {
                list = list.Where(x => x.ProductName.Contains(ProductName));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.BarCode,
                x.ProductName,
                MeasureName = x.MeasureName,
                CateName = x.CateName,
                x.CreateTime,
                x.Size,
                x.Remark,
                x.InPrice
            });
            var info = new
            {
                count = total,
                code = 0,
                data = list1
            };
            return Json(info,JsonRequestBehavior.DenyGet); 
        }
        public ActionResult AddBI_Location()
        {
            List<BI_LocaType> bll = new BI_LocaTypeManager().GetAll();
            ViewBag.BI_ProductCategoryList = new SelectList(bll, "LocalTypeID", "LocalTypeName");
            BI_LocaType info = new BI_LocaType
            {
                LocalTypeID = 0,
                LocalTypeName = "--请选择--"
            };
            return PartialView();
        }
        [HttpGet]
        public ActionResult AddBI_Locations(int page, int limit, string LocalNum)
        {
            var ss = db.BI_Location.ToList();
            var list = from x in db.BI_Location
                       select new
                       {
                           x.LocalNum,
                           x.LocalName,
                           LocalTypeName=x.BI_LocaType.LocalTypeName,
                           x.IsForbid,
                           x.IsDefault,
                           x.CreateTime
                       };
            if (!String.IsNullOrEmpty(LocalNum))
            {
                list = list.Where(x => x.LocalNum.Contains(LocalNum));
            }
            int total = list.Count();
            var list1 = list.OrderByDescending(x => x.CreateTime).Skip((page - 1) * limit).Take(limit).Select(x => new
            {
                x.LocalNum,
                x.LocalName,
                x.LocalTypeName,
                x.IsForbid,
                x.IsDefault,
                x.CreateTime
            });
            var info = new
            {
                count = total,
                code = 0,
                data = list1
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        }
}
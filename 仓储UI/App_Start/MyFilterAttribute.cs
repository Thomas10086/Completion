using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.App_Start
{
    public class MyFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 登录，权限过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var info = filterContext.HttpContext.Session["ADMIN"] as Admin;
            if (info == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admint/Login");
            }
        }
    }
}
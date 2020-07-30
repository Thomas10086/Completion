using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 仓储Model;

namespace 仓储UI.App_Start
{
    public class MyFilterAtterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var info = filterContext.HttpContext.Session["Admiats"] as Admin;
            if (info == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Login");
            }
        }
    }
}
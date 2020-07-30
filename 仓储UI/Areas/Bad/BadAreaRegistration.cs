using System.Web.Mvc;

namespace 仓储UI.Areas.Bad
{
    public class BadAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Bad";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bad_default",
                "Bad/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "仓储UI.Areas.Bad.Controllers" }
            );
        }
    }
}
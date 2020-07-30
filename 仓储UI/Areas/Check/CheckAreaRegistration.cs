using System.Web.Mvc;

namespace 仓储UI.Areas.Check
{
    public class CheckAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Check";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Check_default",
                "Check/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "仓储UI.Areas.Check.Controllers" }
            );
        }
    }
}
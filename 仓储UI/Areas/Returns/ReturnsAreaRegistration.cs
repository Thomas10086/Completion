using System.Web.Mvc;

namespace 仓储UI.Areas.Returns
{
    public class ReturnsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Returns";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Returns_default",
                "Returns/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "仓储UI.Areas.Returns.Controllers" }
            );
        }
    }
}
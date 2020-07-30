using System.Web.Mvc;

namespace 仓储UI.Areas.OutStorage
{
    public class OutStorageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OutStorage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OutStorage_default",
                "OutStorage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "仓储UI.Areas.OutStorage.Controllers" }
            );
        }
    }
}
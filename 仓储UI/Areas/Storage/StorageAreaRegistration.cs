using System.Web.Mvc;

namespace 仓储UI.Areas.Storage
{
    public class StorageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Storage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Storage_default",
                "Storage/{controller}/{action}/{id}",
                new { action = "List", id = UrlParameter.Optional },
                namespaces: new string[] { "仓储UI.Areas.Storage.Controllers" }
            );
        }
    }
}
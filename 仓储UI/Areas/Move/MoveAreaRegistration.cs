using System.Web.Mvc;

namespace 仓储UI.Areas.Move
{
    public class MoveAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Move";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Move_default",
                "Move/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "仓储UI.Areas.Move.Controllers" }
            );
        }
    }
}
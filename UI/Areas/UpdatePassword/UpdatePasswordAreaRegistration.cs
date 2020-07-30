using System.Web.Mvc;

namespace 仓储UI.Areas.UpdatePassword
{
    public class UpdatePasswordAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UpdatePassword";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UpdatePassword_default",
                "UpdatePassword/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
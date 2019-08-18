using System.Web.Mvc;

namespace AllittaMMC.Areas.TallentAdmin
{
    public class TallentAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TallentAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TallentAdmin_default",
                "TallentAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces:new[] { "AllittaMMC.Areas.TallentAdmin.Controllers" }
            );
        }
    }
}
using System.Web.Mvc;

namespace Eticaret.WebUI.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
               "adminProdutcUpdate",
               "admin/Products/Update/{ID}]",
               new { controller = "Products", action = "Update", id = UrlParameter.Optional }
           );

            context.MapRoute(
                "admin",
                "admin",
                new { controller ="Default", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
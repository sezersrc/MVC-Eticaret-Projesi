using System.Web.Mvc;
using System.Web.Routing;

namespace Eticaret.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Kampanyalar",
                "Kampanyalar",
                new { controller = "Campaign", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "iletisim",
                "iletisim",
                new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Kategoriler",
                "Kategori/{KategoriAdi}",
                new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
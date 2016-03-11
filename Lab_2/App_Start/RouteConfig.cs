using System.Web.Mvc;
using System.Web.Routing;

namespace Lab_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{name}",
                defaults: new
                {
                    controller = "Start",
                    action = "Index",
                    name = UrlParameter.Optional
                }
            );
        }
    }
}

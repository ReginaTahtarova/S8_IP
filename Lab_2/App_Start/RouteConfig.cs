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
                name: "Start",
                url: "",
                defaults: new
                {
                    controller = "Start",
                    action = "Index"
                }
            );

            routes.MapRoute(
                name: "Create",
                url: "notepad/create",
                defaults: new
                {
                    controller = "Start",
                    action = "Create"
                }
            );

            routes.MapRoute(
                name: "ShowNotepad",
                url: "notepad/{name}",
                defaults: new
                {
                    controller = "Start",
                    action = "Show",
                    name = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Image",
                url: "Start/Image/{name}",
                defaults: new
                {
                    controller = "Start",
                    action = "Image",
                    name = UrlParameter.Optional
                }
            );
        }
    }
}

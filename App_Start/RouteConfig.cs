using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllittaMMC
{
    public class RouteConfig
    {


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Xidmet",
                url: "Xidmet/Index/{id}",
                defaults: new { controller = "Xidmet", action = "Index", id = 1 }
            );

            routes.MapRoute(
                name: "Tours",
                url: "Tours/Single/{id}",
                defaults: new { controller = "Tours", action = "Single", id = 1 }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

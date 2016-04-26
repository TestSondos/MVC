using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("sondos", "sondos/{name}",
                new { controller = "sondos", action = "Search", name = UrlParameter.Optional }
                );

            routes.MapRoute("sondossamii", "sondossamii/{name}",
                new { controller = "sondossamii", action ="Search2", name = UrlParameter.Optional}
                );

            routes.MapRoute("patient", "patient/{name}",
                new { controller = "patient", action = "Index", name = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ISay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    name: "Create",
                    url: "Create",
                    defaults: new { controller = "Blogs", action = "Create" }
             );

            routes.MapRoute(
                    name: "Blogs",
                    url: "Blogs/{tag}",
                    defaults: new { controller = "Blogs", action = "Index", tag = "BossSay" }
             );

            routes.MapRoute(
                name: "FindMe",
                url: "FindMe/{action}",
                defaults: new
                {
                    controller = "FindMe",
                    action = "Index"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "AboutMe",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

        }
    }
}

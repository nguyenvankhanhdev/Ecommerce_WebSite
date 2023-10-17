using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name:"Default",
                url: "{controller}/{action}/{id}",
                defaults: new {Controller ="Home", Action ="Index", id= UrlParameter.Optional},
                namespaces: new[] {"WebsiteProject.Controllers"} 

                );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace WebApplication1.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*panthInfo}");

            routes.MapRoute(
                name : "Default",
                url : "{controller}/{action}/{id}",
                defaults : new {controller = "Home",action = "Index", id = UrlParameter.Optional},
                namespaces: new string[] { "PortfolioManagerInterface.Controllers" }
                );

        }
    }
}
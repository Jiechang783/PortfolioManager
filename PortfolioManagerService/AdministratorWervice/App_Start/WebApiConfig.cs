﻿using EntityFramwork.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdministratorWervice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
        

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           

            var enableCorsAttribute = new EnableCorsAttribute("*",
                                               "Origin, Content-Type, Accept",
                                               "GET, PUT, POST, DELETE, OPTIONS");
        }
    }
}

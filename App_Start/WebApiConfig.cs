﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CoolvisionTest
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
                routeTemplate: "api/{controller}/{country}",
                defaults: new
                {
                    country = RouteParameter.Optional
                }
            );
        }
    }
}
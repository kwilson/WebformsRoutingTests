using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebformsRoutingTests
{
    using System.IO;

    using WebformsRoutingTests.App_Start;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();

            routes.MapRoute("home", "", "default.aspx");
        }
    }

    public static class RouteExtensions
    {
        private static string ClientId = "LA"; // this would come from config

        public static void MapRoute(this RouteCollection routes, string name, string url, string viewPath)
        {
            MapRoute(routes, ClientId, name, url, viewPath);
        } 

        public static void MapRoute(RouteCollection routes, string clientId, string name, string url, string viewPath)
        {
            var clientPath = Path.Combine("~/Views", clientId, viewPath);
            if (File.Exists(HttpContext.Current.Server.MapPath(clientPath)))
            {
                // Map client URL
                routes.MapPageRoute(name, url, clientPath);
            }
            else if (!string.IsNullOrWhiteSpace(clientId))
            {
                // Fallback to non-client URL
                MapRoute(routes, string.Empty, name, url, viewPath);
            }
        }
    }
}

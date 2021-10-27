// <copyright file="RouteConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// RouteConfig.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// RegisterRoutes.
        /// </summary>
        /// <param name="routes">RouteCollection.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FizzBuzz", action = "DisplayFizzBuzz", id = UrlParameter.Optional });
        }
    }
}

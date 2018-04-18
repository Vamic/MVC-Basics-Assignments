using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TemperatureChecker",
                url: "FeverCheck",
                defaults: new { controller = "Main", action = "TemperatureChecker" }
            );
            
            routes.MapRoute(
                name: "NumberGuessing",
                url: "GuessingGame",
                defaults: new { controller = "Main", action = "NumberGuessing" }
            );

            routes.MapRoute(
                name: "PeopleV2",
                url: "People/v2/{action}/{id}",
                defaults: new { controller = "PeopleV2", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

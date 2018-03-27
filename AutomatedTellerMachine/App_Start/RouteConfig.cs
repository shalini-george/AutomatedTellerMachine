using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutomatedTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); //path with .axd is for ceratin resources and system utilities and dealt by 
                                                              //seperate handler

            //retrieve serial number of our ATM
            routes.MapRoute(
                name: "Serial number",
                url: "serial/{letterCase}", //letter case place holder to allow user to enter lower case serial number
                defaults: new { controller = "Home", action = "Serial", letterCase = "upper" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}

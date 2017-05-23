using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Intranet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Area",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Area", action = "Index", id = UrlParameter.Optional }
            );

           // routes.MapRoute(
           //   name: "Area",
           //   url: "Cliente/Listar/{range}/{filtro}",
           //   defaults: new { controller = "Cliente", action = "Listar", range = UrlParameter.Optional, filtro = UrlParameter.Optional }
           //);

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}

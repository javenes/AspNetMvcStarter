using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kurs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("Nr 3", "Movie", new  { controller = "Movie", Action = "Index" }); UNØDIG
            //routes.MapRoute("Nr 3", "Movie", new { controller = "Movie", Action = "Index" });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute("Nr 5", "Movie/Genre/{genrename}", new { controller = "Movie", action = "MoviesByGenre" });

            routes.MapRoute("nr 9", "Person/{id}", new { controller = "Person", action = "Details" }, new { id = @"\d+" });

            // routes.MapRoute("nr 10", "Image/{format}/{id}.jpg", new { controller = "Image", action = "CreateImage" });

            routes.MapRoute("Vis en film", "Movie/Details/{id}", new { controller = "Movie", action = "Details" }, new { id = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

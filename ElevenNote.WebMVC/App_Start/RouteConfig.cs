using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElevenNote.WebMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", 
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

                // {controller} is the particular controller we are using. For this project, chances are it will be Note.
                // {action} is the ActionResult we are calling on (Create, Details, Edit, or Delete).
                // {id} is an optional parameter that will only be used when we are working with a specific note. We'll add the NoteId to the end of the Url in these cases.

                // is is possible to set the route so that the note is note the Id but the Title or some other thing? 
            );
        }
    }
}

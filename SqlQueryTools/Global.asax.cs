using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SqlQueryTools
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            var jsBundle = new Bundle("~/Scripts/js", new JsMinify());
            jsBundle.AddFile("~/Scripts/jquery-1.7.2.js");
            jsBundle.AddFile("~/Scripts/modernizr-2.5.3.js");
            jsBundle.AddFile("~/Scripts/jquery.tipsy.js");
            jsBundle.AddFile("~/Scripts/knockout.js");
            jsBundle.AddFile("~/Scripts/jquery.clippy.min.js");
            jsBundle.AddFile("~/scripts/ListTool.js");
            BundleTable.Bundles.Add(jsBundle);

            var cssBundle = new Bundle("~/Content/css", new CssMinify());
            cssBundle.AddDirectory("~/Content/", "*.css", true);
            BundleTable.Bundles.Add(cssBundle);
        }
    }
}
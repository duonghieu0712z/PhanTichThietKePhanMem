using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class Global : HttpApplication
    {
        public static string g_PageSize = "20";
        public static string g_PageSize2 = "5";
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
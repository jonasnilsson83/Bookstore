using ApplicationFacadeService;
using Microsoft.Practices.Unity;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BookstoreWeb
{
    public class Global : HttpApplication
    {
        public static ApplicationFacadeService.ApplicationFacadeService _facade;
        
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            _facade = new ApplicationFacadeService.ApplicationFacadeService();

        }
    }
}
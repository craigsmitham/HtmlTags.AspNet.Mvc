using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HtmlTags.AspNet.Mvc;

namespace MvcWebsite
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            HtmlTagsConfig.Configure(HtmlTagsConfiguration.Configuration);
        }
    }
}

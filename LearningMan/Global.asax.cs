using LearningMan.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LearningMan
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacInitializer.Initialize(); // My dependency resolver
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}

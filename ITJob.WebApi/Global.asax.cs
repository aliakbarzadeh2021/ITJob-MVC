using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ITJob.Infrastructure.Configuration;
using ITJob.WebApi.Startup;

namespace ITJob.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            InfrastructureBootstrapper.Start();
            WebApiBootstrapper.Start(InfrastructureBootstrapper.Container);

            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(new WebConfigApplicationSettings());
        }
    }
}

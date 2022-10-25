using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using ITJob.WebApi.Installers;

namespace ITJob.WebApi.Startup
{
    public static class WebApiBootstrapper
    {

        public static void Start(IWindsorContainer windsorContainer)
        {
            InfrastructureBootstrapper.Start();

            windsorContainer.Install(new WebApiInstaller());

        }


         
    }
}
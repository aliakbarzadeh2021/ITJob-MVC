using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using ITJob.Service.Installers;

namespace ITJob.WebApi.Startup
{
    public static class InfrastructureBootstrapper
    {
        static InfrastructureBootstrapper()
        {
            Container = new WindsorContainer();
        }

        public static IWindsorContainer Container
        {
            get; set;
        }

        public static void Start()
        {
            Container.Install(new ServiceInstaller());
        }
        public static void Stop()
        {
            Container.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using ITJob.Host.Api.Installers;
using ITJob.Service.Installers;

namespace ITJob.Host.Api.Resolver
{
    public class DependencyContainer
    {
        public static IWindsorContainer Container { get; private set; }

        public DependencyContainer()
        {
            Container = new WindsorContainer();
        }

        public void Start()
        {
            Container.Install(new HostInstaller());
        }
        public static void Stop()
        {
            Container.Dispose();
        }
    }
}

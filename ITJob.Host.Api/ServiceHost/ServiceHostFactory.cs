using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ITJob.Host.Api.ServiceHost
{
    public class ServiceHostFactory
    {
        public static void Run()
        {
            HostFactory.Run(configurator =>
            {
                configurator.SetServiceName("RESTApiService");
                configurator.SetDisplayName("REST Api Service");
                configurator.SetDescription("Service for IT Job Advertisement");
                configurator.RunAsLocalService();
                configurator.Service<ServiceHost>(hostSettings =>
                {
                    hostSettings.ConstructUsing(builder => new ServiceHost());
                    hostSettings.WhenStarted(service => service.Start());
                    hostSettings.WhenStopped(service => service.Stop());
                });
            });
        }
    }
}

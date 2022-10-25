using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace ITJob.Host.Api.Resolver
{
    public class ApiDependencyResolver : IDependencyResolver
    {
        public IWindsorContainer Container { get; private set; }

        public ApiDependencyResolver(IWindsorContainer container)
        {
            Container = container;
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return Container.Kernel.HasComponent(serviceType) ? Container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.ResolveAll(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            return new DefaultDependencyScope(Container);
        }
    }
}

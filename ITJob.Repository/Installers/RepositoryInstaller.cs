using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.DomainModel.Installers;
using ITJob.Infrastructure.Repository;
using ITJob.Infrastructure.UnitOfWork;
using Component = System.ComponentModel.Component;

namespace ITJob.Repository.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(IRepository<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(IUnitOfWork))
                .WithServiceDefaultInterfaces()
                .LifestyleTransient());

            container.Install(new DomainInstaller());
        }
    }
}

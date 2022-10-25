using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.Repository.Installers;
using ITJob.Service.Dto;
using ITJob.Service.Interfaces;
using AdvertismentModel= ITJob.DomainModel.Advertisement.Aggregates.Advertisement;

namespace ITJob.Service.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IApplicationService>()
                .WithServiceDefaultInterfaces()
                .LifestyleTransient());

            container.Install(new RepositoryInstaller());

            AutoMapper.Mapper.Initialize(Config);
        }

        private void Config(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression
                .CreateMap<AdvertismentModel, AdvertisementDto>();
            mapperConfigurationExpression
                .CreateMap<AdvertisementDto, AdvertismentModel>();
        }
    }
}

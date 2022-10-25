using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Advertis= ITJob.DomainModel.Advertisement.Aggregates.Advertisement;

namespace ITJob.Service.Dto.Convertor
{
    public static class AdvertisementConvertor
    {
        public static AdvertisementDto ToDto(Advertis domainClass)
        {
            var dto = new AdvertisementDto();
            AutoMapper.Mapper.Map(domainClass, dto);
            return dto;
        }

        public static IEnumerable<AdvertisementDto> ToDto(IEnumerable<Advertis> advertisements)
        {
            var advertisementDtos = new List<AdvertisementDto>();
            foreach (var domainClass in advertisements)
            {
                var dto = new AdvertisementDto();
                AutoMapper.Mapper.Map(domainClass, dto);
                advertisementDtos.Add(dto);
            }
            
            return advertisementDtos;
        }

        public static Advertis ToDomainClass(AdvertisementDto dto)
        {
            var domainClass = new Advertis();
            AutoMapper.Mapper.Map(dto, domainClass);
            return domainClass;
        }

        public static Expression<Func<Advertis, bool>> ToDomainClass(Expression<Func<AdvertisementDto, bool>> query)
        {
            Expression<Func<Advertis, bool>> newQuery = x => true;
            return newQuery;
        }

        
    }
}

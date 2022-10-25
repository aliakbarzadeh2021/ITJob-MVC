using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Advertisement.Interfaces;
using ITJob.Service.Dto;
using ITJob.Service.Dto.Convertor;
using ITJob.Service.Interfaces;

namespace ITJob.Service.Advertisement
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public void CreateNewAdvertisement(AdvertisementDto advertisement)
        {
            var param = AdvertisementConvertor.ToDomainClass(advertisement);
            _advertisementRepository.AddNewAdvertisement(param);
        }

        public void UpdateAdvertisement(AdvertisementDto advertisement)
        {
            var param = AdvertisementConvertor.ToDomainClass(advertisement);
            _advertisementRepository.UpdateAdvertisement(param);
        }

        public void DeleteAdvertisement(AdvertisementDto advertisement)
        {
            var param = AdvertisementConvertor.ToDomainClass(advertisement);
            _advertisementRepository.DeleteAdvertisement(param);
        }

        public void ConfirmAdvertisement(AdvertisementDto advertisement)
        {
            var param = AdvertisementConvertor.ToDomainClass(advertisement);
            _advertisementRepository.UpdateAdvertisement(param);
        }

        public AdvertisementDto GetAdvertisementById(Guid id)
        {
            var result = _advertisementRepository.FindAdvertisementById(id);
            return AdvertisementConvertor.ToDto(result);
        }

        public IEnumerable<AdvertisementDto> SearchAdvertisement(Expression<Func<AdvertisementDto, bool>> query)
        {
            var newquery = AdvertisementConvertor.ToDomainClass(query);
            var result = _advertisementRepository.FindAdvertisement(newquery);
            return AdvertisementConvertor.ToDto(result);
        }
    }
}

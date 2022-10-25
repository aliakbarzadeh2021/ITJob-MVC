using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.Service.Dto;

namespace ITJob.Service.Interfaces
{
    public interface IAdvertisementService : IApplicationService
    {
        void CreateNewAdvertisement(AdvertisementDto advertisement);
        void UpdateAdvertisement(AdvertisementDto advertisement);
        void DeleteAdvertisement(AdvertisementDto advertisement);
        void ConfirmAdvertisement(AdvertisementDto advertisement);

        AdvertisementDto GetAdvertisementById(Guid id);
        IEnumerable<AdvertisementDto> SearchAdvertisement(Expression<Func<AdvertisementDto, bool>> query);
    }
}

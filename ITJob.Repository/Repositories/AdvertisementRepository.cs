using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Advertisement.Aggregates;
using ITJob.DomainModel.Advertisement.Interfaces;
using ITJob.Infrastructure.UnitOfWork;

namespace ITJob.Repository.Repositories
{
    public class AdvertisementRepository : RepositoryBase<Advertisement, Guid>, IAdvertisementRepository
    {
        public AdvertisementRepository()
        {
        }

        public void AddNewAdvertisement(Advertisement adver)
        {
            adver.Id = Guid.NewGuid();
            Add(adver);
        }

        public void UpdateAdvertisement(Advertisement adver)
        {
            Update(adver);
        }

        public void DeleteAdvertisement(Advertisement adver)
        {
            Remove(adver);
        }

        public Advertisement FindAdvertisementById(Guid id)
        {
            return FindBy(id);
        }

        public IEnumerable<Advertisement> FindAdvertisement(Expression<Func<Advertisement, bool>> query)
        {
            return ListBy(query);
        }
    }
}

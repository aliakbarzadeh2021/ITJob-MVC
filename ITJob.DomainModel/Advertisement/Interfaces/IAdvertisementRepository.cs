using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.Infrastructure.Repository;
using T= ITJob.DomainModel.Advertisement.Aggregates.Advertisement;


namespace ITJob.DomainModel.Advertisement.Interfaces
{
    public interface IAdvertisementRepository : IRepository<T,Guid>
    {
        void AddNewAdvertisement(T adver);
        void UpdateAdvertisement(T adver);
        void DeleteAdvertisement(T adver);

        T FindAdvertisementById(Guid id);
        IEnumerable<T> FindAdvertisement(Expression<Func<T, bool>> query);

    }
}

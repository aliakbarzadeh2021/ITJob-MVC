using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ITJob.Infrastructure.Domain;

namespace ITJob.Infrastructure.Repository
{
	public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : IAggregateRoot
	{
	    void Add(T entity);

	    void Remove(T entity);

	    void Update(T entity);

	    void SaveOrUpdate(T entity);

    }
}
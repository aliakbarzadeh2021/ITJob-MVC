using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.Infrastructure;
using ITJob.Infrastructure.Domain;
using ITJob.Infrastructure.UnitOfWork;
using ITJob.Repository.Context;

namespace ITJob.Repository.Repositories
{
    public abstract class RepositoryBase<T, TEntityKey> where T : class, IAggregateRoot
    {
      
        private readonly EntityFrameworkDbContext _context;
        private readonly DbSet<T> _entity;

        //protected IUnitOfWork Uow;
        //protected RepositoryBase(IUnitOfWork uow)
        //{
        //    Uow = uow;
        //    _context = new EntityFrameworkDbContext();
        //    _contextOfT = _context.Set<T>();
        //}

        protected RepositoryBase()
        {
            _context = new EntityFrameworkDbContext();
            _entity = _context.Set<T>();
        }

        //public virtual void Commit()
        //{
        //    Uow.Commit();
        //}

        public void Add(T entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _entity.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveOrUpdate(T entity)
        {
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T FindBy(TEntityKey id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return _entity;
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return _entity.Skip(index).Take(count);
        }

        public T SingleBy(Expression<Func<T, bool>> query)
        {
            return _entity.Where(query).SingleOrDefault();
        }

        public virtual IList<T> ListBy(Expression<Func<T, bool>> query)
        {
            return _entity.Where(query).ToList();
        }

        public IEnumerable<T> PagedListBy(Expression<Func<T, bool>> query, int pageIndex, int pageSize)
        {
            return _entity.Where(query).Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IEnumerable<T> PagedListBy(int pageIndex, int pageSize)
        {
            return _entity.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IEnumerable<T> PagedListBy(Expression<Func<T, bool>> query, int pageIndex, int pageSize,
            out int recordCount)
        {
            recordCount = _entity.Where(query).Count();
            return _entity.Where(query).Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}
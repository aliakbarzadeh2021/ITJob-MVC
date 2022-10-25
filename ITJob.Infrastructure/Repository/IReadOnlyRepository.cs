using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ITJob.Infrastructure.Repository
{
	public interface IReadOnlyRepository<T, TId>
	{

		//void Commit();

		T FindBy(TId id);
		IEnumerable<T> FindAll();

		T SingleBy(Expression<Func<T, bool>> query);
	
		IList<T> ListBy(Expression<Func<T, bool>> query);

		/// <summary>
		/// دریافت لیست صفحه بندی شده
		/// </summary>
		/// <param name="query">Query مد نظر</param>
		/// <param name="pageIndex">شماره صفحه</param>
		/// <param name="pageSize">تعداد رکوردها در هر صفحه</param>
		/// <returns>لیست صفحه بندی شده</returns>
		IEnumerable<T> PagedListBy(Expression<Func<T, bool>> query, int pageIndex, int pageSize);

		/// <summary>
		/// دریافت لیست صفحه بندی شده
		/// </summary>
		/// <param name="pageIndex">شماره صفحه</param>
		/// <param name="pageSize">تعداد رکوردها در هر صفحه</param>
		/// <returns>لیست صفحه بندی شده</returns>
		IEnumerable<T> PagedListBy(int pageIndex, int pageSize);

		/// <summary>
		/// دریافت لیست صفحه بندی شده
		/// </summary>
		/// <param name="query">Query مد نظر</param>
		/// <param name="pageIndex">شماره صفحه</param>
		/// <param name="pageSize">تعداد رکوردها در هر صفحه</param>
		/// <param name="recordCount">تعداد کل رکورد ها </param>
		/// <returns>لیست صفحه بندی شده</returns>
		IEnumerable<T> PagedListBy(Expression<Func<T, bool>> query, int pageIndex, int pageSize, out int recordCount);
        
	    IEnumerable<T> FindAll(int index, int count);

    }
}
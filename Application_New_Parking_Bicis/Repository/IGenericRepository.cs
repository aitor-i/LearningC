using System;
using System.Linq.Expressions;
using Data_Parking_Bicis.Entity;

namespace Application_Parking_Bicis.Repository
{
    public interface IGenericRepository<T> where T : EntityBase
	{
		Task<IEnumerable<T>> GetValues();
		Task<int> Insert(T entity);
		IQueryable<T> GetQuery();
        IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate);
        Task<T?> Find(int id);
		Task<IEnumerable<T>> Search(Expression<Func<T,bool>> predicate);
        Task<T> Edit(T newElement, int id);


    }
}


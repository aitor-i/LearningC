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
		Task<T?> Find(T predicate);
		Task<IEnumerable<T>> Search(Expression<Func<T,bool>> predicate);
	}
}


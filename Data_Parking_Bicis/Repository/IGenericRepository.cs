using System;
using Data_Parking_Bicis.Models;

namespace Data_Parking_Bicis.Repository
{
	public interface IGenericRepository<T> where T : EntityBase
	{
		Task<IEnumerable<T>> GetValues();
		Task<int> Insert(T entity);
	}
}


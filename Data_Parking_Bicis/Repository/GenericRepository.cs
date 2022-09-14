using System;
using Data_Parking_Bicis.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Parking_Bicis.Repository
{
	public class GenericRepository<T>:IGenericRepository<T> where T : EntityBase
	{
        protected readonly DbContext _ctx;
		public GenericRepository(DbContext ctx)
		{
            _ctx = ctx;
		}

        public IQueryable<T> GetQuery()
        {
            return _ctx.Set<T>();
        }

        public async Task<IEnumerable<T>> GetValues()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<int> Insert(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity.Id;
        }
    }
}


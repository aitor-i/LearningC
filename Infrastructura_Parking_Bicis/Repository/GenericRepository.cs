using System;
using System.Linq.Expressions;
using Application_Parking_Bicis.Repository;
using Data_Parking_Bicis.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura_Parking_Bicis
{
	public class GenericRepository<T>:IGenericRepository<T> where T : EntityBase
	{
        protected readonly DbContext _ctx;
		public GenericRepository(DbContext ctx)
		{
            _ctx = ctx;
		}

        public async Task<T?> Find(int id)
        {
            
           
                T? element = await _ctx.Set<T>().FindAsync( id);
                return element;
            
        
        }

        public IQueryable<T> GetQuery()
        {
            return _ctx.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().AsNoTracking().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetValues()
        {

            return await _ctx.Set<T>().AsNoTracking().ToListAsync();
        } 

        public async Task<int> Insert(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T,bool>> predicate)
        {
            /* IEnumerable<T>? collection;
            var names = typeof(T).GetProperties()
                                 .Select(property => property.Name)
                                 .ToArray();
            foreach (var name in names)
            {
                collection.Append(await _ctx.Set<T>().Where(x => x.name.ToString() == predicate).ToListAsync());
            } */


            // await _ctx.Set<T>().FindAsync(predicate).ToListAsync();
            return await _ctx.Set<T>().Where(predicate).ToListAsync();
            
        }

        public async Task<T> Edit(T newElement, int id)
        {
            var element = await _ctx.Set<T>().FindAsync(id);
            element = newElement;
             _ctx.SaveChanges();

            return element;
            // var user
            // var user.username = newUsername
            // await _ctx.SaveChangesAsync()
        }
    }
}


﻿using System;
using System.Linq.Expressions;
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

        public async Task<T?> Find(T predicate)
        {
            
           
                T element = await _ctx.Set<T>().FindAsync(predicate.Id);
                return element;
            
        
        }

        public IQueryable<T> GetQuery()
        {
            return _ctx.Set<T>().AsNoTracking();
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

        public async Task<IEnumerable<T>> Search(string predicate)
        {
            /*IEnumerable<T>? collection;
            var names = typeof(T).GetProperties()
                                 .Select(property => property.Name)
                                 .ToArray();
            foreach (var name in names)
            {
                collection.Append(await _ctx.Set<T>().Where(x => x.name.ToString() == predicate).ToListAsync());
            }*/

            
            // await _ctx.Set<T>().FindAsync(predicate).ToListAsync();
            throw new NotImplementedException();
        }
    }
}


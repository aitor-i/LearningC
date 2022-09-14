using System;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Repository;
using Data_Parking_Bicis.UOW;
using Microsoft.EntityFrameworkCore;

namespace Data_Parking_Bicis.UOW
{
	public class UnitOfWork: IUnitOfWork, IDisposable
	{
        public IUserRepository UserRepository { get; private set; }
        private readonly DataContext _ctx;
		public UnitOfWork()
		{

		}

        public UnitOfWork(DataContext ctx)
        {
            UserRepository = new UserRepository(ctx);
            _ctx = ctx;
        }

        public async Task CompleteAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}


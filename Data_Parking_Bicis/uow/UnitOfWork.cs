using System;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Repository;
using Data_Parking_Bicis.uow;
using Microsoft.EntityFrameworkCore;

namespace Data_Parking_Bicis.uow
{
	public class UnitOfWork: IUnitOfWork, IDisposable
	{
        public IUserRepository UserRepository { get; private set; }
        public IHistoryRepository HistoryRepository { get; private set; }
        public IParkingRepository ParkingRepository { get; private set; }
        public IPasswordRepository PasswordRepository { get; private set; }

        private readonly DataContext _ctx;
		public UnitOfWork()
		{

		}

        public UnitOfWork(DataContext ctx)
        {
            HistoryRepository = new HistoryRepository(ctx);
            ParkingRepository = new ParkingRepository(ctx);
            UserRepository = new UserRepository(ctx);
            PasswordRepository = new PasswordRepository(ctx);

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


using System;
using Application_Parking_Bicis.Repository;

namespace Application_Parking_Bicis.UOW
{
    public interface IUnitOfWork
	{
        IUserRepository UserRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        IParkingRepository ParkingRepository { get; }
        IPasswordRepository PasswordRepository { get; }
        Task CompleteAsync();
    }
}


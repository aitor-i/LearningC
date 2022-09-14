using System;
using Data_Parking_Bicis.Repository;

namespace Data_Parking_Bicis.UOW
{
	public interface IUnitOfWork
	{
        IUserRepository UserRepository { get; }
        Task CompleteAsync();
    }
}


﻿using System;
using Data_Parking_Bicis.Repository;

namespace Data_Parking_Bicis.uow
{
	public interface IUnitOfWork
	{
        IUserRepository UserRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        Task CompleteAsync();
    }
}


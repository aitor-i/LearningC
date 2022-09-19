using System;
using Application_Parking_Bicis.Repository;
using Data_Parking_Bicis.Model;
using Infrastructura_Parking_Bicis;

namespace Data_Parking_Bicis.Repository
{
	public class HistoryRepository:GenericRepository<History>, IHistoryRepository
    {
		public HistoryRepository(DataContext ctx): base(ctx)
		{
		}


    }
}


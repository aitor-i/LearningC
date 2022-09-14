using System;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;

namespace Data_Parking_Bicis.Repository
{
	public class HistoryRepository:GenericRepository<History>, IHistoryRepository
    {
		public HistoryRepository(DataContext ctx): base(ctx)
		{
		}


    }
}


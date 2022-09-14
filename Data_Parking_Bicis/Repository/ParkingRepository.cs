using System;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;

namespace Data_Parking_Bicis.Repository
{
	public class ParkingRepository:GenericRepository<Parkings>, IParkingRepository
    {
		public ParkingRepository(DataContext ctx): base(ctx)
		{
		}
    }
}


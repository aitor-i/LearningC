using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.ViewModels;

namespace Application_Parking_Bicis.Interfaces
{
	public interface IParkingActions
	{
		Task<IEnumerable<ParkingViewModel>> GetAllParkings();
	}
}


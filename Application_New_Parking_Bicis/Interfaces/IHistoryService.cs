using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.ViewModels;

namespace Application_Parking_Bicis.Interfaces
{
	
	public interface IHistoryService
	{
		// IActionResult ?
		 Task<IEnumerable<HistoryViewModel>>  GetAllHistory();
		Task<int> NewParkingUsage(HistoryViewModel newParkingRegistration);
	}
}

	
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;

namespace Application_Parking_Bicis.Servicios.Interfaces
{
	
	public interface IHistoryService
	{
		// IActionResult ?
		Task<ServiceQueryResponse<HistoryViewModel>>  GetAllHistory();
		Task<ServiceComandResponse> NewParkingUsage(HistoryViewModel newParkingRegistration);
		Task<ServiceQueryResponse<HistoryViewModel>> SearchHistory(string patern);

    }
}

	
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;

namespace Application_Parking_Bicis.Interfaces
{
	public interface IParkingService
	{
		Task<ServiceQueryResponse<ParkingViewModel>> GetAllParkings();
		Task<ServiceQueryResponse<ParkingViewModel>> FindParking(ParkingViewModel parkingToFind);

    }
}


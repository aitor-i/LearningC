﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;

namespace Application_Parking_Bicis.Servicios.Interfaces
{
    public interface IParkingService
	{
		Task<ServiceQueryResponse<ParkingViewModel>> GetAllParkings();
		Task<ServiceQueryResponse<ParkingViewModel>> FindParking(int id);
		Task<ServiceComandResponse> NewParking(NewParkingForm parkingForm);
		Task<ServiceComandResponse> ChangeParkingName(ParkingViewModel newParking);

    }
}


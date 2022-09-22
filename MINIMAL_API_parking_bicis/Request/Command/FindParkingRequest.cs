﻿using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace API_parking_bicis.Request.Command
{
	public class FindParkingRequest: IRequest<ServiceComandResponse>
	{
		public ParkingViewModel Parking { get; set; }
		public FindParkingRequest(ParkingViewModel parking)
		{
			Parking = parking;
		}
	}
}


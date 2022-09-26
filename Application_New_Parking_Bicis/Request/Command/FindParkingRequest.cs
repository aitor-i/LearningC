using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace Application_Parking_Bicis.Request.Command
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


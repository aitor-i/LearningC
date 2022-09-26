using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace Application_Parking_Bicis.Request.Command
{
	public class NewParkingRequest: IRequest<ServiceComandResponse>
	{
		public NewParkingForm ParkingForm { get; set; }
		public NewParkingRequest(NewParkingForm parkingForm)
		{
			ParkingForm = parkingForm;
		}
	}
}


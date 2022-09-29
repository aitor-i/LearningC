using System;
using Application_Parking_Bicis.Message;
using MediatR;

namespace Application_Parking_Bicis.Request.Command
{
	public class ChangeParkingNameRequest:IRequest<ServiceComandResponse>
	{
		public string NewParkingName { get; set; }
		public int ParkingId { get; set; }
		public ChangeParkingNameRequest(string newParkingName, int parkingId)
		{
			NewParkingName = newParkingName;
			ParkingId = parkingId;
		}
	}
}


using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;
using MediatR;

namespace MINIMAL_API_parking_bicis.Request.Query
{
	public class FindParkingRequest: IRequest<ServiceQueryResponse<ParkingViewModel>>
	{
		public int Id { get; set; }
		public FindParkingRequest(int id)
		{
			Id = id;
		}
	}
}


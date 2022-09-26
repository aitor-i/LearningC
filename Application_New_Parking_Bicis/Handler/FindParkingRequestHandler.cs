using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;
using MediatR;
using Application_Parking_Bicis.Request.Query;

namespace Application_Parking_Bicis.Handler
{
	public class FindParkingRequestHandler:	IRequestHandler<FindParkingRequest, ServiceQueryResponse<ParkingViewModel>>
	{
        private readonly IParkingService _service;
		public FindParkingRequestHandler(IParkingService service)
		{
            _service = service;
		}

        public async Task<ServiceQueryResponse<ParkingViewModel>> Handle(FindParkingRequest request, CancellationToken cancellationToken)
        {
            return await _service.FindParking(request.Id);

        }
    }
}


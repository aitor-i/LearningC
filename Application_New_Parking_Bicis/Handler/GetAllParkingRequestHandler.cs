using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using MediatR;
using Application_Parking_Bicis.Request.Query;

namespace Application_Parking_Bicis.Handler
{
    public class GetAllParkingRequestHandler: IRequestHandler<GetAllParkingRequest, ServiceQueryResponse<ParkingViewModel>>
	{
        private readonly IParkingService _service;
		public GetAllParkingRequestHandler(IParkingService service)
		{
            _service = service;
		}

        public async Task<ServiceQueryResponse<ParkingViewModel>> Handle(GetAllParkingRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllParkings();
        }
    }
}


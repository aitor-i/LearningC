using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Request.Command;
using Application_Parking_Bicis.Servicios.Interfaces;
using MediatR;

namespace Application_Parking_Bicis.Handler
{
	public class NewParkingRequestHandler:IRequestHandler<NewParkingRequest, ServiceComandResponse>
	{
        private readonly IParkingService _service;
		public NewParkingRequestHandler(IParkingService service)
		{
            _service = service;
		}

        public async Task<ServiceComandResponse> Handle(NewParkingRequest request, CancellationToken cancellationToken)
        {
            return await _service.NewParking(request.ParkingForm);
        }
    }
}


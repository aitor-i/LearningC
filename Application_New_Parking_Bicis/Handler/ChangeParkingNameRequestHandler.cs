using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Request.Command;
using Application_Parking_Bicis.Servicios.Interfaces;
using MediatR;

namespace Application_Parking_Bicis.Handler
{
	public class ChangeParkingNameRequestHandler: IRequestHandler<ChangeParkingNameRequest, ServiceComandResponse>
	{
        private readonly IParkingService _service;
		public ChangeParkingNameRequestHandler(IParkingService service)
		{
            _service = service;
		}

    
        public async Task<ServiceComandResponse> Handle(ChangeParkingNameRequest request, CancellationToken cancellationToken)
        {
            return await _service.ChangeParkingName(request.NewParkin);
        }
    }
}


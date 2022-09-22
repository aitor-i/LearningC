using System;
using API_parking_bicis.Request.Command;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using MediatR;
using MINIMAL_API_parking_bicis.Request.Query;

namespace MINIMAL_API_parking_bicis.Handler
{
    public class NewParkingUsageRequestHandler:IRequestHandler<RegisterNewParkingUsageRequest, ServiceComandResponse>
	{
        private readonly IHistoryService _service;
        public NewParkingUsageRequestHandler(IHistoryService service)
		{
        _service = service;
		}

        public async Task<ServiceComandResponse> Handle(RegisterNewParkingUsageRequest request, CancellationToken cancellationToken)
        {
            return await _service.NewParkingUsage(request.UsageReuqest);
        }
    }
}

    
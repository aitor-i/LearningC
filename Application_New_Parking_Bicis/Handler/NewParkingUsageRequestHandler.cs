using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using MediatR;
using Application_Parking_Bicis.Request.Query;

namespace Application_Parking_Bicis.Handler
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

    
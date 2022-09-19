using System;
using API_parking_bicis.Request.Query;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace API_parking_bicis.Handler
{
	public class GetAllHistoryRequestHandler: IRequestHandler<GetAllHistoryRequest, ServiceQueryResponse<HistoryViewModel>>

	{
        private readonly IHistoryService _service;
        public GetAllHistoryRequestHandler(IHistoryService service)
		{
            _service = service;
		}

        public async Task<ServiceQueryResponse<HistoryViewModel>> Handle(GetAllHistoryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllHistory();
        }
    }
}


using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using MediatR;
using Application_Parking_Bicis.Request.Query;

namespace Application_Parking_Bicis.Handler
{
    public class SearchRequestHandler: IRequestHandler<SearchRequest, ServiceQueryResponse<HistoryViewModel>>
    {
        private readonly IHistoryService _service;
		public SearchRequestHandler(IHistoryService service)
		{
            _service = service;
		}

        public async Task<ServiceQueryResponse<HistoryViewModel>> Handle(SearchRequest request, CancellationToken cancellationToken)
        {
            return await _service.SearchHistory(request.Expression);
        }
    }
}


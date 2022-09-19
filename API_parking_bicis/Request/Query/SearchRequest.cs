using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace API_parking_bicis.Request.Query
{
	public class SearchRequest: IRequest<ServiceQueryResponse<HistoryViewModel>>
    {
		public string Expression { get; set; }
		public  SearchRequest(string expresion)
		{
			Expression = expresion;
		}
	}
}


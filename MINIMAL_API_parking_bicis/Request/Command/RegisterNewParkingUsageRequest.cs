using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace MINIMAL_API_parking_bicis.Request.Query
{
    public class RegisterNewParkingUsageRequest: IRequest<ServiceComandResponse>
    {
		public HistoryViewModel UsageReuqest { get; set; }
		public RegisterNewParkingUsageRequest(HistoryViewModel usageRequest )
		{
			UsageReuqest = usageRequest;
		}
	}
}


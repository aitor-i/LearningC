using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace API_parking_bicis.Request.Command
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


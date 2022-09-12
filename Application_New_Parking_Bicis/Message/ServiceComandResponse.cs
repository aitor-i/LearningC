using System;
namespace Application_Parking_Bicis.Message
{
	public class ServiceComandResponse
	{
		public bool IsSuccess { get; set; }
		public int Response { get; set; } =  -1;

		public ServiceComandResponse()
		{
		}
	}
}


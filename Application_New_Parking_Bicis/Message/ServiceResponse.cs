using System;
namespace Application_Parking_Bicis.Message
{
	public class ServiceQueryResponse <T>
	{
		public bool IsSuccess { get; set; } = false;
		public IEnumerable<T>? Data { get; set; } = null;
		public  ServiceQueryResponse()
		{
		}
	}
}

	
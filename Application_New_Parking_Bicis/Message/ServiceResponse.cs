using System;
namespace Application_Parking_Bicis.Message
{
	public class ServiceQueryResponse <T>
	{
		public bool IsSuccess { get; set; }
		public IEnumerable<T>? Data { get; set; }
		public  ServiceQueryResponse()
		{
		}
	}
}


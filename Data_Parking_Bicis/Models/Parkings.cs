using System;
using Data_Parking_Bicis.Models;

namespace Data_Parking_Bicis.Model
{
	public class Parkings:EntityBase
	{

		public string ParkinName { get; set; } = string.Empty;
		public int UsersId { get; set; }

		public ICollection<History>? HistoryCollection { get; set; } = null;

		public Users? User { get; set; } = null;
		public Parkings()
		{
		}
	}
}	


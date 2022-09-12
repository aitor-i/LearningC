using System;
namespace API_parking_bicis.Models
{
	public class Parkings
	{

		public int Id { get; set; }
		public string ParkinName { get; set; } = string.Empty;
		public int UsersId { get; set; }

		public ICollection<History>? HistoryCollection { get; set; } = null;

		public Users? User { get; set; } = null;
		public Parkings()
		{
		}
	}
}	


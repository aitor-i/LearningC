	using System;
namespace API_parking_bicis.Models
{
	public class Users
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public int UserTypeId { get; set; }

		public ICollection<Parkings>? ParkingCollection { get; set; } = null;
        public ICollection<History>? HistoryCollection { get; set; } = null;
		public Passwords Passwords { get; set; }

		public UserType? UserType { get; set; } = null;


		public Users()
		{
		}
	}
}

			
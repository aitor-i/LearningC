	using System;
using Data_Parking_Bicis.Models;

namespace Data_Parking_Bicis.Model
{
	public class Users:EntityBase
	{
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

			
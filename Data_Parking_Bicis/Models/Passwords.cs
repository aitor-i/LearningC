using System;
using Data_Parking_Bicis.Models;

namespace Data_Parking_Bicis.Model
{
	public class Passwords:EntityBase
	{
		public string Password { get; set; } = string.Empty;
		public int UsersId { get; set; }

        public Users? User { get; set; } = null;

        public Passwords()
		{
		}	
	}
}


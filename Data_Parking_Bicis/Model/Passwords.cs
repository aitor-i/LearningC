using System;
namespace API_parking_bicis.Models
{
	public class Passwords
	{
		public int Id { get; set; }
		public string Password { get; set; } = string.Empty;
		public int UsersId { get; set; }

        public Users? User { get; set; } = null;

        public Passwords()
		{
		}	
	}
}


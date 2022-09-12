using System;
namespace API_parking_bicis.Models
{
	public class UserType
	{
		public int Id { get; set; }
		public string Type { get; set; } = String.Empty;

		public ICollection<Users>? UserCollection { get; set; } = null;

		public UserType()
		{
		}
	}
}


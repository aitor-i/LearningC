using System;
namespace Data_Parking_Bicis.Model
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


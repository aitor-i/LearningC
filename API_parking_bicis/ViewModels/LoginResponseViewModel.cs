using System;
namespace API_parking_bicis.ViewModels
{
	public class LoginResponseViewModel
	{
		public bool IsLogged { get; set; }
		public int UserId { get; set; }

		public LoginResponseViewModel()
		{
		}
	}
}


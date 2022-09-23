using System;
namespace Application_Parking_Bicis.ViewModels
{
    public class LoginResponseViewModel
	{
		public bool IsLogged { get; set; }
		public int UsersId { get; set; }
		public int? UserType { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public LoginResponseViewModel()
		{
		}
	}
}


using System;
namespace Application_Parking_Bicis.ViewModels
{
    public class UserViewModelNewUser:UserViewModel
	{
		public string Password { get; set; } = string.Empty;


		public UserViewModelNewUser()
		{
		}
	}
}


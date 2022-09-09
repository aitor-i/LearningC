using System;
namespace API_parking_bicis.ViewModels
{
	public class UserViewModelNewUser:UserViewModel
	{
		public string Password { get; set; } = string.Empty;


		public UserViewModelNewUser()
		{
		}
	}
}


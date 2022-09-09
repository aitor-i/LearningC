using System;
using System.Threading.Tasks;
using Application_Parking_Bicis.ViewModels;

namespace Application_Parking_Bicis.Interfaces
{
	public interface EmptyInterface
	{
		Task Login(LoginViewModel loginForm);
		Task RegisterNewUser(UserViewModelNewUser newUser);

	}
}


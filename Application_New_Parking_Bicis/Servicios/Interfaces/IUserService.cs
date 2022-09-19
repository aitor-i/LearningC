using System;
using System.Threading.Tasks;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;

namespace Application_Parking_Bicis.Servicios.Interfaces
{
    public interface IUserInterface
	{
		Task<ServiceComandResponse> Login(LoginViewModel loginForm);
		Task<ServiceComandResponse> RegisterNewUser(UserViewModelNewUser newUser);

	}
}


using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace API_parking_bicis.Request.Command
{
	public class LoginRequest:IRequest<ServiceComandResponse>
	{
		public LoginViewModel LoginData { set; get; } 
		public LoginRequest(LoginViewModel loginData)
		{
			LoginData = loginData;
		}
	}
}


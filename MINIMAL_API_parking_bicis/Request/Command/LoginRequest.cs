using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace MINIMAL_API_parking_bicis.Request.Query
{
    public class LoginRequest:IRequest<ServiceQueryResponse<LoginResponseViewModel>>
	{
		public LoginViewModel LoginData { set; get; } 
		public LoginRequest(LoginViewModel loginData)
		{
			LoginData = loginData;
		}
	}
}


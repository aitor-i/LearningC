using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using MediatR;

namespace MINIMAL_API_parking_bicis.Request.Query
{
    public class PostNewUserRequest: IRequest<ServiceComandResponse>
	{
		public UserViewModelNewUser NewUserForm { get; set; }
		public PostNewUserRequest(UserViewModelNewUser newUserForm)
		{
			NewUserForm = newUserForm;
		}
	}
}


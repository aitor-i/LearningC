using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using MediatR;
using Application_Parking_Bicis.Request.Query;
using Application_Parking_Bicis.Request.Command;

namespace Application_Parking_Bicis.Handler
{
    public class PostNewUserRequestHandler:IRequestHandler<PostNewUserRequest, ServiceComandResponse>
	{
        private readonly IUserInterface _service;
		public PostNewUserRequestHandler(IUserInterface service)
		{
            _service = service;
		}

        public async Task<ServiceComandResponse> Handle(PostNewUserRequest request, CancellationToken cancellationToken)
        {
            return await _service.RegisterNewUser(request.NewUserForm);
        }
    }
}


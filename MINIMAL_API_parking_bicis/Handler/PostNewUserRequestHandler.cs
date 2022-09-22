using System;
using API_parking_bicis.Request.Command;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using MediatR;
using MINIMAL_API_parking_bicis.Request.Query;

namespace MINIMAL_API_parking_bicis.Handler
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


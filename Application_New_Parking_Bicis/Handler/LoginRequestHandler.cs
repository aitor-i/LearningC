using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using MediatR;
using Application_Parking_Bicis.Request.Query;

namespace Application_Parking_Bicis.Handler
{
    public class LoginRequestHandler: IRequestHandler<LoginRequest, ServiceQueryResponse<LoginResponseViewModel>>
	{
        private readonly IUserInterface _service;
		public LoginRequestHandler(IUserInterface service)
		{
            _service = service;
		}

        public async Task<ServiceQueryResponse<LoginResponseViewModel>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            return await _service.Login(request.LoginData);
        }
    }
}


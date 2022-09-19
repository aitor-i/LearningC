using System;
using AutoMapper;

namespace Application_Parking_Bicis.Servicios
{
	public abstract class BaseService
	{
		protected readonly IMapper _mapper;


	
        public BaseService( IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}


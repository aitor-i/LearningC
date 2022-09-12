using System;
using AutoMapper;
using Data_Parking_Bicis.data;

namespace Application_Parking_Bicis.Servicios
{
	public abstract class BaseService
	{
		protected readonly DataContext _ctx;
		protected readonly IMapper _mapper;


		public BaseService(DataContext ctx, IMapper mapper)
		{
			_ctx = ctx;
			_mapper = mapper;
		}
	}
}


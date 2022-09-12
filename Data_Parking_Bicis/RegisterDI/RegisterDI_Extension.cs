using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application_Parking_Bicis.RegisterDI
{
	public static class RegisterDI_Extension
	{
		public static IServiceCollection AddApplicationDependency(this IServiceCollection service )
		{
			service.AddAutoMapper(Assembly.GetExecutingAssembly());
			return service;
		}
	}
}


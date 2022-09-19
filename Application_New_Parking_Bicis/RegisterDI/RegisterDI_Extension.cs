using System;
using System.Reflection;
using Application_Parking_Bicis.Servicios;
using Application_Parking_Bicis.Servicios.Interfaces;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data_Parking_Bicis.RegisterDI
{
	public static class RegisterDI_Extension
	{
        public static IServiceCollection AddApplicationDependency(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddTransient<IHistoryService, HistoryService>();
            service.AddTransient<IParkingService, ParkingService>();
            service.AddTransient<IUserInterface, UserService>();


            return service;
        }
    }
}


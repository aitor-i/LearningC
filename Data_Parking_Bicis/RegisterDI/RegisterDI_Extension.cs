using System;
using System.Reflection;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application_Parking_Bicis.RegisterDI
{
	public static class RegisterDI_Extension
	{
	

        public static IServiceCollection AddDataDependency(this IServiceCollection service, IConfiguration configuration)
        {

            SqlConnectionStringBuilder config = new SqlConnectionStringBuilder(configuration.GetConnectionString("connectionString"));
            config.UserID = configuration.GetSection("databaseEnvVars")["username"];
            config.Password = configuration.GetSection("databaseEnvVars")["password"];
            service.AddDbContext<DataContext>(options => options.UseSqlServer(config.ConnectionString));
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IHistoryRepository, HistoryRepository>();
            service.AddTransient<IParkingRepository, ParkingRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IPasswordRepository, PasswordRepository>();

            return service;
        }
    }
}


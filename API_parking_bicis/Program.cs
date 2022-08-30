using System.Reflection;
using API_parking_bicis.data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SqlConnectionStringBuilder config = new SqlConnectionStringBuilder("Server=localhost,1433;Initial Catalog=BicisApp;Encrypt=false;TrustServerCertificate=False;Connection Timeout=30;");
config.UserID = "SA";
config.Password = "Aitor123";
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(config.ConnectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


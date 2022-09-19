using System.Reflection;
using Data_Parking_Bicis.RegisterDI;
using Infrastructura_Parking_Bicis.RegisterDI;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string dato1 = builder.Configuration.GetSection("misDatos")["dato1"];

// Add services to the container.
builder.Services.AddInfrastructureDependency((builder.Configuration));
builder.Services.AddApplicationDependency();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myCors",
        policy => policy.WithOrigins("http://localhost:3000",
                                    "http://www.contoso.com")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                        );
   
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("myCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
  

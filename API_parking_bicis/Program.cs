﻿using System.Reflection;
using API_parking_bicis.data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string dato1 = builder.Configuration.GetSection("misDatos")["dato1"];

// Add services to the container.
SqlConnectionStringBuilder config = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("connectionString"));
config.UserID = builder.Configuration.GetSection("databaseEnvVars")["username"] ;
config.Password = builder.Configuration.GetSection("databaseEnvVars")["password"];
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


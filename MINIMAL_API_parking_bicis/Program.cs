﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Data_Parking_Bicis.RegisterDI;
using Infrastructura_Parking_Bicis.RegisterDI;
using Infrastructura_Parking_Bicis;
using AutoMapper;
using Application_Parking_Bicis.Servicios.Interfaces;
using AutoMapper.QueryableExtensions;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddInfrastructureDependency(builder.Configuration);
builder.Services.AddApplicationDependency();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Parking bicis
app.MapGet("/history/all-history", async (IHistoryService _history_service) => {

    var allHistoriesCollection = await _history_service.GetAllHistory();
    return allHistoriesCollection;
});

app.MapGet("history/all-history-slim", async (DataContext _ctx, IMapper _mapper) =>
{
    var allHistoriesCollection = await _ctx.Histories.ProjectTo<HistorySlimViewModel>(_mapper.ConfigurationProvider).ToListAsync();

    

    return allHistoriesCollection;
});

app.MapGet("history/by-parking-name", async (DataContext _ctx, IMapper _mapper, [FromQuery] string parkingName) =>
{
    var parkingHistoryCollection = await _ctx.Histories
                                                 .Where(history => history.Parking.ParkinName.ToLower() == parkingName.ToLower())
                                                 .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                 .ToListAsync();

    return parkingHistoryCollection;
});

app.MapGet("history/by-username", async (DataContext _ctx, IMapper _mapper, [FromQuery] string username) =>{

    Users user = await _ctx.Users.SingleAsync(user => user.Username == username);
    IEnumerable<History> userHistoryCollection = await _ctx.Histories.Where(history => history.UserId == user.Id).Include(history => history.Parking).ToListAsync();
      

    return _mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(userHistoryCollection);
});

app.MapGet("history/by-user-id", async (DataContext _ctx, IMapper _mapper, [FromQuery] int userId) =>
{
    IEnumerable<HistoryViewModel> histoyesCollection = await _ctx.Histories.Where(history => history.Id == userId).ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider).ToArrayAsync();
    return histoyesCollection;
});

app.MapPost("history/new-parking-usage", async (DataContext _ctx, History usageForm, IValidator<History> _validator) =>
{
    try
    {
        var result = _validator.Validate(usageForm);
        if (!result.IsValid)
        {
            return Results.BadRequest(result.Errors);

        }
        await _ctx.Histories.AddAsync(usageForm);
        await _ctx.SaveChangesAsync();

        return Results.Ok( usageForm.Id);

    }
    catch (Exception ex)
    {
        return  Results.Problem(statusCode:500, detail:ex.Message);
    }

});

// API run
app.Run();  

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

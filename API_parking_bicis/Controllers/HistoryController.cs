using System;
using Application_Parking_Bicis.Interfaces;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_parking_bicis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _service;
        public HistoryController(IHistoryService service)
        {
            _service = service;
        }
        
        [HttpGet("AllHistory")]
        public async Task<IActionResult> GetAllHistory()
        {

            return Ok(await _service.GetAllHistory());
        }

        /*

        [HttpGet("AllHistorySlim")]
        public async Task<IActionResult> GetAllHistorySlim()
        {
            var allHistoriesCollection = await _ctx.Histories.ProjectTo<HistorySlimViewModel>(_mapper.ConfigurationProvider).ToListAsync();

            // var allHistoriesCollection = await _ctx.Histories
                                                //.ToListAsync();
      
           // var mappedHistoriesCollection = _mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(allHistoriesCollection);

            return Ok(allHistoriesCollection);
        }

        [HttpGet("HistoryByParkingName")]
        public async Task<IActionResult> GetHistoryByParkingName([FromQuery] string parkingName)
        {

            // List<Parkings> parkingsCollection = await _ctx.Parkings.Where(Parking => Parking.ParkinName == parkingName).ToListAsync(); // Sacar el primero

            //  Parkings parking = await _ctx.Parkings.SingleAsync(parking => parking.ParkinName == parkingName);
            // IEnumerable<History> parkingHistoryCollection = await _ctx.Histories.Where(history => history.ParkingId  == parking.Id).Include(history => history.User).ToListAsync();
            var parkingHistoryCollection = await _ctx.Histories
                                                     .Where(history => history.Parking.ParkinName.ToLower() == parkingName.ToLower())
                                                     .ProjectTo<HistorySlimViewModel>(_mapper.ConfigurationProvider)
                                                     .ToListAsync();

            /* var parkingHistoryCollection2 = await _ctx.Histories
                                             .Where(history => history.Parking.ParkinName.ToLower() == parkingName.ToLower())
                                             .Select(x => new HistoryViewModel { })
                                             .ToListAsync();
            

            return Ok(parkingHistoryCollection);
        }
        
        [HttpGet("HistorybyUsername")]
        public async Task<IActionResult> GetHistoryByUsername([FromQuery] string username)
        {
            Users user = await _ctx.Users.SingleAsync(user => user.Username == username);
            IEnumerable<History> userHistoryCollection = await _ctx.Histories.Where(history => history.UserId == user.Id).Include(history => history.Parking).ToListAsync();


            return Ok(_mapper.Map<IEnumerable<History>, IEnumerable<HistorySlimViewModel>>(userHistoryCollection));


        }
        

        [HttpGet("HistoryByUserId")]
        public async Task<IActionResult> GetHistoryByUserId([FromQuery] int userId)
        {
            IEnumerable<HistorySlimViewModel> histoyesCollection = await _ctx.Histories.Where(history => history.Id == userId).ProjectTo<HistorySlimViewModel>(_mapper.ConfigurationProvider).ToArrayAsync();
            return Ok(histoyesCollection);
        }

        [HttpGet("HistoryByParkingId")]
        public async Task<IActionResult> GetHistoryByParkingId([FromQuery] int parkingId)
        {
            try
            {
                IEnumerable<History> historiesCollection = await _ctx.Histories.Where(history => history.ParkingId == parkingId).ToArrayAsync();

                IEnumerable<HistorySlimViewModel> mappedHistoriesCollection = _mapper.Map<IEnumerable<History>, IEnumerable<HistorySlimViewModel>>(historiesCollection);
                return Ok(historiesCollection);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error");
            }
        }
        */

        [HttpPost("NewParkingUsage")]
        public async Task<IActionResult> NewParkingUsage(HistoryViewModel usageForm)
        {

            return Ok(await _service.NewParkingUsage(usageForm));
        }
        


    }
}


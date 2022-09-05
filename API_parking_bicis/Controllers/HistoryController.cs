using System;
using API_parking_bicis.data;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_parking_bicis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public HistoryController(DataContext ctx, IMapper mapper)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        [HttpGet("AllHistory")]
        public async Task<IActionResult> GetAllHistory()
        {
            var allHistoriesCollection = await _ctx.Histories.ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider).ToListAsync();


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
                                                     .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                     .ToListAsync();

            /* var parkingHistoryCollection2 = await _ctx.Histories
                                             .Where(history => history.Parking.ParkinName.ToLower() == parkingName.ToLower())
                                             .Select(x => new HistoryViewModel { })
                                             .ToListAsync();
            */

            return Ok(parkingHistoryCollection);
        }
        [HttpGet("HistorybyUsername")]
        public async Task<IActionResult> GetHistoryByUsername([FromQuery] string username)
        {
            Users user = await _ctx.Users.SingleAsync(user => user.Username == username);
            IEnumerable<History> userHistoryCollection = await _ctx.Histories.Where(history => history.UserId == user.Id).Include(history => history.Parking).ToListAsync();


            return Ok(_mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(userHistoryCollection));


        }

        [HttpGet("HistoryByUserId")]
        public async Task<IActionResult> GetHistoryByUserId([FromQuery] int userId)
        {
            IEnumerable<HistoryViewModel> histoyesCollection = await _ctx.Histories.Where(history => history.Id == userId).ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider).ToArrayAsync();
            return Ok(histoyesCollection);
        }

        [HttpGet("HistoryByParkingId")]
        public async Task<IActionResult> GetHistoryByParkingId([FromQuery] int parkingId)
        {
            try
            {
                IEnumerable<History> historiesCollection = await _ctx.Histories.Where(history => history.ParkingId == parkingId).ToArrayAsync();
                IEnumerable<HistoryViewModel> mappedHistoriesCollection = _mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(historiesCollection);
                return Ok(historiesCollection);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error");
            }
        }


        [HttpPost("NewParkingUsage")]
        public async Task<IActionResult> NewParkingUsage(History usageForm)
        {

            try
            {
                await _ctx.Histories.AddAsync(usageForm);
                await _ctx.SaveChangesAsync();
                return Ok(usageForm.Id);


            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }


    }
}


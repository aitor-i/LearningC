using System;
using API_parking_bicis.data;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;
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
            var allHistoriesCollection = await _ctx.Histories.Include(history => history.Parking).Include(history => history.User).ToListAsync();
            var mappedHistoryCollection = _mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(allHistoriesCollection);

            return Ok(mappedHistoryCollection);
        }

        [HttpGet("HistoryByParkingName")]
        public async Task<IActionResult> GetHistoryByParkingName([FromQuery] string parkingName){

            // List<Parkings> parkingsCollection = await _ctx.Parkings.Where(Parking => Parking.ParkinName == parkingName).ToListAsync(); // Sacar el primero
            Parkings parking = await _ctx.Parkings.SingleAsync(parking => parking.ParkinName == parkingName);
            IEnumerable<History> parkingHistoryCollection = await _ctx.Histories.Where(history => history.ParkingId  == parking.Id).Include(history => history.User).ToListAsync();
            var mappedParkingHistoryCollection = _mapper.Map<IEnumerable<History>,IEnumerable<HistoryViewModel>> (parkingHistoryCollection);
            return Ok(mappedParkingHistoryCollection);
        }
        [HttpGet("HistorybyUsername")]
        public async Task<IActionResult> GetHistoryByUsername([FromQuery] string username)
        {
            Users user = await _ctx.Users.SingleAsync(user => user.Username == username);
            IEnumerable<History> userHistoryCollection = await _ctx.Histories.Where(history => history.UserId == user.Id).Include(history => history.Parking).ToListAsync();


            return Ok(_mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(userHistoryCollection));


        }

        [HttpGet("HistoryByUserId")]
        public async Task<IActionResult> GetHistoryByUserId([FromQuery] int userId){
            IEnumerable<History> histoyesCollection = await _ctx.Histories.Where(history => history.Id == userId).ToArrayAsync();
            IEnumerable<HistoryViewModel> mappedHistoiriesCollection = _mapper.Map<IEnumerable<History>, IEnumerable<HistoryViewModel>>(histoyesCollection);
            return Ok(mappedHistoiriesCollection);
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


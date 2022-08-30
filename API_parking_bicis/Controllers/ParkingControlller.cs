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
    public class ParkingController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public ParkingController(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
            
        }

        [HttpPost("RegisterParking")]
        public async Task<IActionResult> PostRegisterParking(Parkings newParking)
        {
            await _ctx.Parkings.AddAsync(newParking);
            await _ctx.SaveChangesAsync();
            
            return Ok(newParking.Id);
        }
        [HttpDelete("DeleteParking")]
        public async Task<IActionResult> DeleteParking(int parkingId)
        {
            Parkings parkingToRemove =await _ctx.Parkings.FindAsync(parkingId);

            if(parkingToRemove is not null)
            {
                _ctx.Parkings.Remove(parkingToRemove);
                _ctx.SaveChangesAsync();    
                return Ok(true);
            }
            return NotFound(false);
        }
        [HttpGet("AllParkings")]
        public async Task<IActionResult> GetAllParkings()
        {
            var parkingsCollection = await _ctx.Parkings.Include(parking => parking.User).ToListAsync();
            var mappedParkingsCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection); 
            return Ok(mappedParkingsCollection  )    ;
        }


    }
}       


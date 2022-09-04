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
            return Ok(mappedParkingsCollection )    ;
        }

        // Pregunta, puedeo hacer un join y luego filtar por elemento del roin? ejm: Añadir username 
        //var parkngsCollection = await _ctx.Parkings.Include(parking => parking.User).Where(parking => parking.User.Username == username).ToListAsync();

        [HttpGet("GetParkingByUser")]
        public async Task<IActionResult> GetParkingByUsername(string username) {
            try
            {
            var user = await  _ctx.Users.SingleAsync(user => user.Username == username);
            
            IList<Parkings> parkingsCollection = await _ctx.Parkings.Where(parkings => parkings.UsersId == user.Id).ToListAsync();
            var mappedParkingCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection);
            return Ok(mappedParkingCollection); 

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetParkingByUserId")]
        public async Task<IActionResult> GetParkingByUserId([FromQuery]int userId)
        {
            IEnumerable<Parkings> parkingsCollection = await _ctx.Parkings.Where(parking => parking.UsersId == userId).Include(parking => parking.User).ToListAsync();
            IEnumerable<ParkingViewModel> mappedParkingCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection);
            return Ok(mappedParkingCollection);
        }


    }
}       


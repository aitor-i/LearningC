using System;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data_Parking_Bicis.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_parking_bicis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _service;
        public ParkingController(IParkingService service)
        {
            _service = service;
            
        }
        /*
        [HttpPost("RegisterParking")]
        public async Task<IActionResult> PostRegisterParking(Parkings newParking)
        {
            var result = _validator.Validate(newParking);

            if (!result.IsValid)
            {
                return StatusCode(404, result.Errors);
            }

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
               await _ctx.SaveChangesAsync();    
                return Ok(true);
            }
            return NotFound(false);
        }
        */
        [HttpGet("AllParkings")]
        public async Task<IActionResult> GetAllParkings()
        {
            var response = await _service.GetAllParkings();
            if (!response.IsSuccess) StatusCode(500);
            return Ok(response.Data ) ;   
        }

        [HttpPost("GetParking")]
        public async Task<IActionResult> GetParking(ParkingViewModel parking)
        {
            var response = await _service.FindParking(parking);
            if (!response.IsSuccess) return StatusCode(500);
            return Ok(response);
        }

        // Pregunta, puedeo hacer un join y luego filtar por elemento del roin? ejm: Añadir username 
        //var parkngsCollection = await _ctx.Parkings.Include(parking => parking.User).Where(parking => parking.User.Username == username).ToListAsync();

        /*
        [HttpGet("GetParkingByUser")]
        public async Task<IActionResult> GetParkingByUsername(string username) {
            try
            {


                IEnumerable<ParkingViewModel> parkingsCollection = await _ctx.Parkings.Where(parking => parking.User.Username == username)
                                                                                        .ProjectTo<ParkingViewModel>(_mapper.ConfigurationProvider)
                                                                                        .ToListAsync();
                return Ok(parkingsCollection); 

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
        */


    }
}       


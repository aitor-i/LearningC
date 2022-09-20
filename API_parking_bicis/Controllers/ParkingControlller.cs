using System;
using API_parking_bicis.Request.Query;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data_Parking_Bicis.Model;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_parking_bicis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _service;
        private readonly IMediator _mediator;
        public ParkingController(IParkingService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
            
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
            var response = await _mediator.Send<ServiceQueryResponse<ParkingViewModel>>(new GetAllParkingRequest());    
            if (!response.IsSuccess) StatusCode(500);
            return Ok(response.Data ) ;   
        }

        [HttpPost("GetParking")]
        public async Task<IActionResult> GetParking(int id)
        {
            var response = await _mediator.Send<ServiceQueryResponse<ParkingViewModel>>(new FindParkingRequest(id));
            if (!response.IsSuccess) return StatusCode(500);
            return Ok(response.Single);
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


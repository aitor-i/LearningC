﻿using System;
using API_parking_bicis.data;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
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
        private readonly IValidator<Parkings> _validator;
        public ParkingController(DataContext ctx, IMapper mapper, IValidator<Parkings> validator)
        {
            _ctx = ctx;
            _mapper = mapper;
            _validator = validator; 
            
        }

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


    }
}       


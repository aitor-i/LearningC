using System;
using API_parking_bicis.Handler;
using API_parking_bicis.Request.Command;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.Model;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_parking_bicis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
	{
        private readonly IUserInterface _service;
        private readonly IMediator _mediator;
        public UsersController(IUserInterface service, IMediator mediator)
        {
            _mediator = mediator;
            _service = service;
        }
        /*
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var userToDelete =await _ctx.Users.FindAsync(userId);
            if (userToDelete is not null )
            {

            _ctx.Users.Remove(userToDelete);
            await _ctx.SaveChangesAsync();
            return Ok(true);
            }
            return BadRequest();
        }
        */
        [HttpPost("NewUser")]
        public async Task<IActionResult> PostNewUser(UserViewModelNewUser newUser)
        {
            var response = await _mediator.Send<ServiceComandResponse>(new PostNewUserRequest(newUser));
            if (!response.IsSuccess) return StatusCode(500);
            return Ok(response.Response); 
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginData)
        {
            var response = await _mediator.Send(new LoginRequest(loginData));
            if (!response.IsSuccess) return StatusCode(500);
            return Ok(response.Response);
        }

        /*
        [HttpPut("ModifyUser")]
        public async Task<IActionResult> ModifyUser(Users updatedUser)
        {
            // var result = _validator.Validate(updatedUser);

           // if (!result.IsValid)
            //{
           //     return StatusCode(400, result.Errors);
           // }
            _ctx.Users.Update(updatedUser);
           await _ctx.SaveChangesAsync();
            return Ok(true);
        }

        [HttpGet("UsersByType")]
        public async Task<IActionResult> GetUsersByType([FromQuery] int type)
        {
           if (type > 2) return BadRequest();
            try
            {
                var usersTypeCollection = await _ctx.Users.Include(x => x.UserType).Where(x => x.UserTypeId == type).ToListAsync();
                var mappedTypeCollection = _mapper.Map<IEnumerable<Users>, IEnumerable<UserViewModel>>(usersTypeCollection);
                 return Ok(mappedTypeCollection); 

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("AllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {

           var usersCollection = await _ctx.Users.Include(x => x.UserType).ToListAsync();
           var mappedCollection = _mapper.Map<IEnumerable<Users>, IEnumerable<UserViewModel>>(usersCollection);
           return Ok(mappedCollection);

        }*/

    }

}


using System;
using API_parking_bicis.data;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_parking_bicis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
	{
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IValidator<Users> _validator;
        public UsersController(DataContext ctx, IMapper mapper, IValidator<Users> validator)
        {
            _ctx = ctx;
            _mapper = mapper;
            _validator = validator;

        }

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

        [HttpPost("NewUser")]
        public async Task<IActionResult> PostNewUser(Users newUser)
        {
            var result = _validator.Validate(newUser);

            if (!result.IsValid)
            {
                return StatusCode(400, result.Errors);
            }


            await _ctx.Users.AddAsync(newUser);
            await _ctx.SaveChangesAsync();
            return Ok(newUser.Id); 
        }
        [HttpPut("ModifyUser")]
        public async Task<IActionResult> ModifyUser(Users updatedUser)
        {
            var result = _validator.Validate(updatedUser);

            if (!result.IsValid)
            {
                return StatusCode(400, result.Errors);
            }
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

        }

    }

}


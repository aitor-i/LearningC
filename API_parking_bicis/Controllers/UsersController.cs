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
        private readonly IValidator<UserViewModelNewUser> _validator;
        public UsersController(DataContext ctx, IMapper mapper, IValidator<UserViewModelNewUser> validator)
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
        public async Task<IActionResult> PostNewUser(UserViewModelNewUser newUser)
        {
            var result = _validator.Validate(newUser);


            var user = _mapper.Map< Users >(newUser);
            Passwords newPassword = new Passwords();
            newPassword.Password = newUser.Password;

            user.Passwords = newPassword;



            if (!result.IsValid)
            {
                return StatusCode(400, result.Errors);
            }

            ;
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return Ok(user.Id); 
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginData)
        {
            try
            {
                var passwordDv = await _ctx.Passwords.Include(pass => pass.User).Where(pass => pass.User.Username == loginData.Username).ToListAsync();

                if (passwordDv.Count == 0) return BadRequest(false);



                if (passwordDv[0].Password == loginData.Password) return Ok(true);

                return StatusCode(418, false);
            }
            catch (Exception ex)
            {   
                return StatusCode(500,ex.Message);
            }
        }
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

        }

    }

}


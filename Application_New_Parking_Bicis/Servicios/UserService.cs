using System;
using Application_Parking_Bicis.Interfaces;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;
using Data_Parking_Bicis.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
	public class UserService: BaseService, IUserInterface

    {
         private IValidator<UserViewModelNewUser> _validator { get; set; }
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;

        public UserService(DataContext ctx, IMapper mapper, IValidator<UserViewModelNewUser> validator, IUserRepository userRepository, IPasswordRepository passwordRepository ) : base(ctx, mapper)
        {
            _validator = validator;
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
        }

        public async Task<ServiceComandResponse> Login(LoginModel loginData)
        {
            ServiceComandResponse commandResponse = new ServiceComandResponse() { IsSuccess = false };
            try
            {
                 // var passwordDv = await _ctx.Passwords.Include(pass => pass.User).Where(pass => pass.User.Username == loginData.Username).ToListAsync();
                // passwordDv = await _passwordRepository.GetValues().Include(pass => pass.User).Where(pass => pass.User.Username == loginData.Username);
                var passwordDv = await _passwordRepository.GetPasswords(loginData);

                if (passwordDv.Count == 0) throw new InvalidDataException();


                if (passwordDv[0].Password == loginData.Password)
                {

                    LoginResponseViewModel response = new LoginResponseViewModel();
                    response.IsLogged = true;
                    response.UserId = passwordDv[0].UsersId;

                    commandResponse.IsSuccess = true;
                    commandResponse.Response = response.UserId;
                    
                        
                }


            }
            catch (Exception ex)
            {
                commandResponse.IsSuccess = false;
              
          
            }
            return commandResponse;
        }

        public async Task<ServiceComandResponse> RegisterNewUser(UserViewModelNewUser newUser)
        {
            ServiceComandResponse comandResponse = new ServiceComandResponse() { IsSuccess = false };
             var result = _validator.Validate(newUser);
            

            try
            {
                if (!result.IsValid) throw new Exception("Invalid new user form");
                var user = _mapper.Map<Users>(newUser);
                Passwords newPassword = new Passwords();
                newPassword.Password = newUser.Password;

                user.Passwords = newPassword;
                var res = await _userRepository.Insert(user);

                comandResponse.IsSuccess = true;
                comandResponse.Response = res;


            }
            catch (Exception ex)
            {
                comandResponse.IsSuccess = false;
            }


            /*
            if (!result.IsValid)
            {
                return StatusCode(400, result.Errors);
            }
            */
            ;
            return comandResponse;
        }
    }
}


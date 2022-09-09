using System;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using FluentValidation;
namespace API_parking_bicis.Validators
{
	public class UserValidator: AbstractValidator<UserViewModelNewUser>
	{
		public UserValidator()
		{
			RuleFor(user => user.Password).NotEmpty().WithMessage("Password is needed!");
			RuleFor(user => user.Username).NotEmpty().WithMessage("Username is needed!");
			RuleFor(user => user.UserTypeId).NotEmpty().WithMessage("User type is a must!");
		}
	}
}

	
using System;
using API_parking_bicis.Models;
using FluentValidation;
namespace API_parking_bicis.Validators
{
	public class UserValidator: AbstractValidator<Users>
	{
		public UserValidator()
		{
			RuleFor(user => user.Password).NotEmpty().WithMessage("Password is needed!");
			RuleFor(user => user.Username).NotEmpty().WithMessage("Username is needed!");
			RuleFor(user => user.UserType).NotEmpty().WithMessage("User type is a must!");
		}
	}
}


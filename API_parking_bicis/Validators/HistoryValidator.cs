using System;
using API_parking_bicis.Models;
using FluentValidation;

namespace API_parking_bicis.Validators
{
	public class HistoryValidator:AbstractValidator<History> 
	{
		public HistoryValidator()
		{
			RuleFor(x => x.StartDate).NotEmpty().WithMessage("Can not be empty");
		}
	}
}


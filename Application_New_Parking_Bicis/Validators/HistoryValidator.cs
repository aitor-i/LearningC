using System;
using Data_Parking_Bicis.Model;
using FluentValidation;

namespace Application_Parking_Bicis.Validators
{
	public class HistoryValidator:AbstractValidator<History> 
	{
		public HistoryValidator()
		{
			RuleFor(x => x.StartDate).NotEmpty().WithMessage("Can not be empty");
		}
	}
}


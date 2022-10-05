using System;
using Application_Parking_Bicis.ViewModels;
using FluentValidation;

namespace Application_Parking_Bicis.Validators
{
	public class NewParkingFormValidator:AbstractValidator<NewParkingForm>
	{
		public NewParkingFormValidator()
		{
			RuleFor(parking => parking.UsersId).NotEmpty().NotNull();
			RuleFor(parking => parking.ParkinName).Length(5, 25);
		}
	}
}


using System;
using Data_Parking_Bicis.Model;
using FluentValidation;

namespace API_parking_bicis.Validators
{
	public class ParkingValidator: AbstractValidator<Parkings>
	{
		public ParkingValidator()
		{

			RuleFor(parking => parking.ParkinName).NotEmpty();
			RuleFor(parking => parking.UsersId).NotNull().NotEmpty();
		}
	}
}


using System;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;

namespace API_parking_bicis.Profiles
{
	public class ParkingProfile:Profile
	{
		public ParkingProfile()
		{
			CreateMap<Parkings, ParkingViewModel>()
				.ForMember(parkingsVM => parkingsVM.Username, parking => parking.MapFrom(parking => (parking.User != null) ? parking.User.Username : String.Empty)
				);	
		}
	}
}

	
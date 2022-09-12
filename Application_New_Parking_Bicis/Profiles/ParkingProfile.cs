using System;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.Model;

namespace Application_Parking_Bicis.Profiles
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

	
using System;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.Model;

namespace Application_Parking_Bicis.Profiles
{
	public class PasswordProfile:Profile
	{
		public PasswordProfile()
		{
			CreateMap<Passwords, LoginResponseViewModel>()
				.ForMember(passVM => passVM.Username, pass => pass.MapFrom(pass => pass.User.Username))
				.ForMember(passVM => passVM.UserType, pass => pass.MapFrom(pass => pass.User.UserTypeId));
		}
	}
}


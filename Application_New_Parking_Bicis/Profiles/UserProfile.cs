using System;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.Model;

namespace Application_Parking_Bicis.Profiles
{
	public class UserProfile:Profile
	{
		
		public UserProfile()
		{
			CreateMap<Users, UserViewModel>()
				.ForMember(x => x.UserTypeName, y => y.MapFrom(z => (z.UserType == null) ? String.Empty : z.UserType.Type));
			CreateMap<UserViewModelNewUser, Users>();
		}
	}
}


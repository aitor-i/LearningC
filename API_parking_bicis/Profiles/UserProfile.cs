using System;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;

namespace API_parking_bicis.Profiles
{
	public class UserProfile:Profile
	{
		
		public UserProfile()
		{
			CreateMap<Users, UserViewModel>()
				.ForMember(x => x.UserTypeName, y => y.MapFrom(z => (z.UserType == null) ? String.Empty : z.UserType.Type));
		}
	}
}


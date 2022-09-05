using System;
using API_parking_bicis.Models;
using API_parking_bicis.ViewModels;
using AutoMapper;

namespace API_parking_bicis.Profiles
{
	public class HistorySlimProfile:Profile
	{
		public HistorySlimProfile()
		{
            CreateMap<History, HistorySlimViewModel>()
                  .ForMember(historyMV => historyMV.ParkingName, history => history.MapFrom(history => (history.Parking != null) ? history.Parking.ParkinName : String.Empty))
                .ForMember(historyMV => historyMV.Username, history => history.MapFrom(history => (history.User != null) ? history.User.Username : String.Empty));


        }
    }
}

            
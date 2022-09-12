using System;
using Data_Parking_Bicis.Model;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;

namespace Application_Parking_Bicis.Profiles
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

            
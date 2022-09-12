using System;
using AutoMapper;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;

namespace Application_Parking_Bicis.Profiles
{
	public class HistoryProfile:Profile
	{
		public HistoryProfile()
		{
			CreateMap<History, HistoryViewModel>()
				  .ForMember(historyMV => historyMV.ParkingName, history => history.MapFrom(history => (history.Parking != null) ? history.Parking.ParkinName : String.Empty))
				.ForMember(historyMV => historyMV.Username, history => history.MapFrom(history => (history.User != null) ? history.User.Username : String.Empty));

			CreateMap<HistoryViewModel, History>();
         /*   CreateMap<History, HistorySlimViewModel>()
                 .ForMember(historyMV => historyMV.ParkingName, history => history.MapFrom(history => (history.Parking != null) ? history.Parking.ParkinName : String.Empty))
               .ForMember(historyMV => historyMV.Username, history => history.MapFrom(history => (history.User != null) ? history.User.Username : String.Empty));
		 */
        }
    }
}


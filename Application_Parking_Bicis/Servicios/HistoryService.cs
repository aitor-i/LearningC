using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.Interfaces;
using Application_Parking_Bicis.ViewModels;

namespace Application_Parking_Bicis.Servicios
{
	public class EmptyClass: IHistoryActions
	{

	    async Task<IEnumerable<HistoryViewModel>> IHistoryActions.GetAllHistory()
		{
		
            IEnumerable<HistoryViewModel> historyCollection =new  List<HistoryViewModel>();

            return historyCollection;
		}
		Task<int> IHistoryActions.NewParkingUsage(HistoryViewModel newParkingRegistration)
		{
			Task<int> nuumbre = new Task<int>(null) ;
			
			return nuumbre;
		}
		public EmptyClass()
		{

		}
	}
}


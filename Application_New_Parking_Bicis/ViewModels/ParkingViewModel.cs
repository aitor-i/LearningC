using System;
namespace Application_Parking_Bicis.ViewModels
{
    public class ParkingViewModel
	{

        public int Id { get; set; }
        public string ParkinName { get; set; } = string.Empty;
        public int UsersId { get; set; }
		public string Username { get; set; } = string.Empty;


		public ParkingViewModel()
		{
		}
	}
}


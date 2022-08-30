using System;
namespace API_parking_bicis.ViewModels
{
	public class HistoryViewModel
	{
        public int Id { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string StopDate { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ParkingId { get; set; }

        public string Username { get; set; }
        public string ParkingName { get; set; }

        public HistoryViewModel()
		{
		}
	}
}


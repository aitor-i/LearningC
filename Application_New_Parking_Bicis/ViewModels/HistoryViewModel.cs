﻿using System;
namespace Application_Parking_Bicis.ViewModels
{
    public class HistoryViewModel
	{
        public int Id { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string StopDate { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ParkingId { get; set; }

        public string Username { get; set; } = string.Empty;
        public string ParkingName { get; set; } = string.Empty;

        public HistoryViewModel()
		{
		}
	}
}

    
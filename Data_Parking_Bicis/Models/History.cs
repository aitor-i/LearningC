﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data_Parking_Bicis.Model
{
	public class History
	{
		public int Id { get; set; }
		public string StartDate { get; set; } = string.Empty;
		public string StopDate { get; set; } = string.Empty;
		public int UserId { get; set; }
		public int ParkingId { get; set; }

		public Users? User { get; set; } = null;
		public Parkings? Parking { get; set; } = null;
			
		public History()
		{
		}
	}
}

using System;
namespace Application_Parking_Bicis.ViewModels
{
    public class HistorySlimViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string ParkingName { get; set; } = string.Empty;

        public HistorySlimViewModel()
        {
        }
    }
}

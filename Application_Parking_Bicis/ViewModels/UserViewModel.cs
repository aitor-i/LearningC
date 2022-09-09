using System;
namespace Application_Parking_Bicis.ViewModels
{
    public class UserViewModel
	{
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; } = string.Empty;


        public UserViewModel()
		{
		}
	}
}


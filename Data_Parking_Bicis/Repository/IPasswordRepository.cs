using System;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;

namespace Data_Parking_Bicis.Repository
{
	public interface IPasswordRepository:IGenericRepository<Passwords>
	{
		Task<List<Passwords>> GetPasswords(string username);
	}

}


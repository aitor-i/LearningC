using System;
using Application_Parking_Bicis.Repository;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.Model;
using Infrastructura_Parking_Bicis;
using Microsoft.EntityFrameworkCore;

namespace Data_Parking_Bicis.Repository
{
	public class PasswordRepository: GenericRepository<Passwords>, IPasswordRepository
	{
		public PasswordRepository(DataContext ctx) :base(ctx)
		{
		}

		public async Task<List<Passwords>> GetPasswords(string username)
		{
			var passList = await _ctx.Set<Passwords>().Where(pass => pass.User.Username == username).Include(pas => pas.User).ToListAsync();
			return passList;

           
        }
	}
}


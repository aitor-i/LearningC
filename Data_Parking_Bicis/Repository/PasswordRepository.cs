using System;
using Application_Parking_Bicis.ViewModels;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Parking_Bicis.Repository
{
	public class PasswordRepository: GenericRepository<Passwords>, IPasswordRepository
	{
		public PasswordRepository(DataContext ctx) :base(ctx)
		{
		}

		public async Task<List<Passwords>> GetPasswords(LoginModel loginData)
		{
            return await _ctx.Set<Passwords>().Include(pass => pass.User).Where(pass => pass.User.Username == loginData.Username).ToListAsync();

           
        }
	}
}


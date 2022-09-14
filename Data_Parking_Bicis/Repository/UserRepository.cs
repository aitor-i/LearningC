using System;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;

namespace Data_Parking_Bicis.Repository
{
	public class UserRepository: GenericRepository<Users>, IUserRepository
	{
		public UserRepository(DataContext ctx): base(ctx)
		{
		}
	}
}


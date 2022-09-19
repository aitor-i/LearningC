using System;
using Data_Parking_Bicis.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura_Parking_Bicis
{
	public class DataContext:DbContext
	{
        public DbSet<History> Histories => Set<History>();
		public DbSet<Users> Users => Set<Users>();
		public DbSet<Parkings> Parkings => Set<Parkings>();
		public DbSet<UserType> UserTypes => Set<UserType>();
        public DbSet<Passwords> Passwords => Set<Passwords>();
        
       


		public DataContext(DbContextOptions<DataContext> options) : base(options) {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DataContext()
		{
            this.ChangeTracker.LazyLoadingEnabled = false;
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>().HasOne(x => x.User).WithMany(x => x.HistoryCollection).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<History>().HasOne(x => x.Parking).WithMany(x => x.HistoryCollection).OnDelete(DeleteBehavior.NoAction);

             base.OnModelCreating(modelBuilder);
        }
    }
}


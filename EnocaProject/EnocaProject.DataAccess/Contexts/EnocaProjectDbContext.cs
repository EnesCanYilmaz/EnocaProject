using System;
using EnocaProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnocaProject.DataAccess.Contexts
{
	public class EnocaProjectDbContext : DbContext
	{
        public EnocaProjectDbContext()
        {
        }

        public EnocaProjectDbContext(DbContextOptions options) : base(options)
		{

		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
        public DbSet<Carrier> Carriers { get; set; }
		public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}


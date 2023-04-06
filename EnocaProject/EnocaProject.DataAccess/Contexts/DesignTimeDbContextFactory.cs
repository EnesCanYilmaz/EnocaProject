using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnocaProject.DataAccess.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EnocaProjectDbContext>
    {
        public EnocaProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EnocaProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}


using System;
using System.Linq.Expressions;
using EnocaProject.Core.Repositories;
using EnocaProject.DataAccess.Contexts;
using EnocaProject.Entities.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EnocaProject.DataAccess
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
        readonly private EnocaProjectDbContext _context;

        public ReadRepository(EnocaProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(int Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}


using System;
using EnocaProject.Core.Repositories;
using EnocaProject.DataAccess.Contexts;
using EnocaProject.Entities.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EnocaProject.DataAccess
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private EnocaProjectDbContext _context;

        public WriteRepository(EnocaProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int Id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Id);
            return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public Task<int> SaveAsync() => _context.SaveChangesAsync();
    }
}


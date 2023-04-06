using System;
using EnocaProject.Entities.Entities.Common;

namespace EnocaProject.Core.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(int Id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}


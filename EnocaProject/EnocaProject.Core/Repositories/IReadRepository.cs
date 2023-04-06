using System;
using System.Linq.Expressions;
using EnocaProject.Entities.Entities.Common;

namespace EnocaProject.Core.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
		IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method, bool tracking = true);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
		Task<T> GetByIdAsync(int Id, bool tracking = true);
    }
}

using System;
using EnocaProject.Entities.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EnocaProject.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}


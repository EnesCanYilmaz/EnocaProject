using System;
using EnocaProject.Entities.Entities;

namespace EnocaProject.Business.Abstract
{
    public interface ICarrierService
    {
        List<Carrier> GetAll();
        Task AddAsync(Carrier carrier);
        Task Update(Carrier carrier);
        Task Delete(int carrierId);
        Task<Carrier> GetById(int carrierId);
    }
}


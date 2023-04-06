using System;
using EnocaProject.Core.Repositories.Carrier;
using EnocaProject.DataAccess.Contexts;

namespace EnocaProject.DataAccess.Repositories.Carrier
{
    public class CarrierWriteRepository : WriteRepository<EnocaProject.Entities.Entities.Carrier>, ICarrierWriteRepository
    {
        public CarrierWriteRepository(EnocaProjectDbContext context) : base(context)
        {
        }
    }
}


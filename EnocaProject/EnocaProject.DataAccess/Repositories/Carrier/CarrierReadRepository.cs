using System;
using EnocaProject.Core.Repositories.Carrier;
using EnocaProject.DataAccess.Contexts;

namespace EnocaProject.DataAccess.Repositories.Carrier
{
    public class CarrierReadRepository : ReadRepository<EnocaProject.Entities.Entities.Carrier>, ICarrierReadRepository
    {
        public CarrierReadRepository(EnocaProjectDbContext context) : base(context)
        {
        }
    }
}


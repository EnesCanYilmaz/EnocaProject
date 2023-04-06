using System;
using EnocaProject.Core.Repositories.CarrierConfiguration;
using EnocaProject.DataAccess.Contexts;

namespace EnocaProject.DataAccess.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationReadRepository : ReadRepository<EnocaProject.Entities.Entities.CarrierConfiguration>, ICarrierConfigurationReadRepository
    {
        public CarrierConfigurationReadRepository(EnocaProjectDbContext context) : base(context)
        {
        }
    }
}


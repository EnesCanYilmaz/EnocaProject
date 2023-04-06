using System;
using EnocaProject.Core.Repositories.CarrierConfiguration;
using EnocaProject.DataAccess.Contexts;

namespace EnocaProject.DataAccess.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationWriteRepository : WriteRepository<EnocaProject.Entities.Entities.CarrierConfiguration>, ICarrierConfigurationWriteRepository
    {
        public CarrierConfigurationWriteRepository(EnocaProjectDbContext context) : base(context)
        {
        }
    }
}


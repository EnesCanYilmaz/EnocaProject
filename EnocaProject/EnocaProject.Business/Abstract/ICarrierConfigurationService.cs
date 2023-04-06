using System;
using EnocaProject.Entities.Entities;

namespace EnocaProject.Business.Abstract
{
	public interface ICarrierConfigurationService
	{
        List<CarrierConfiguration> GetAll();
        Task AddAsync(CarrierConfiguration carrierConfiguration);
        Task Update(CarrierConfiguration carrierConfiguration);
        Task Delete(int carrierConfigurationId);
        Task<CarrierConfiguration> GetById(int carrierConfigurationId);
    }
}


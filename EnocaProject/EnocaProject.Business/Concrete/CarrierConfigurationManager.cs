using System;
using System.Threading;
using EnocaProject.Business.Abstract;
using EnocaProject.Core.Repositories.CarrierConfiguration;
using EnocaProject.Entities.Entities;

namespace EnocaProject.Business.Concrete
{
	public class CarrierConfigurationManager : ICarrierConfigurationService
	{
		private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CarrierConfigurationManager(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public List<CarrierConfiguration> GetAll()
        {
            return _carrierConfigurationReadRepository.GetAll().ToList();

        }

        public async Task AddAsync(CarrierConfiguration carrierConfiguration)
        {
            await _carrierConfigurationWriteRepository.AddAsync(carrierConfiguration);
            await _carrierConfigurationWriteRepository.SaveAsync();
        }

        public async Task Update(CarrierConfiguration carrierConfiguration)
        {
            _carrierConfigurationWriteRepository.Update(carrierConfiguration);
            await _carrierConfigurationWriteRepository.SaveAsync();
        }

        public async Task Delete(int carrierConfigurationId)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(carrierConfigurationId);
            await _carrierConfigurationWriteRepository.SaveAsync();
        }

        public async Task<CarrierConfiguration> GetById(int carrierConfigurationId)
        {
            return await _carrierConfigurationReadRepository.GetByIdAsync(carrierConfigurationId);
            await _carrierConfigurationWriteRepository.SaveAsync();
        }
    }
}


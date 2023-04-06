using System;
using EnocaProject.Business.Abstract;
using EnocaProject.Core.Repositories.Carrier;
using EnocaProject.Entities.Entities;

namespace EnocaProject.Business.Concrete
{
    public class CarrierManager : ICarrierService
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;


        public CarrierManager(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task AddAsync(Carrier carrier)
        {
            await _carrierWriteRepository.AddAsync(carrier);
            await _carrierWriteRepository.SaveAsync();
        }

        public async Task Delete(int carrierId)
        {
            await _carrierWriteRepository.RemoveAsync(carrierId);
            await _carrierWriteRepository.SaveAsync();
        }

        public List<Carrier> GetAll()
        {
            return _carrierReadRepository.GetAll().ToList();

        }

        public async Task<Carrier> GetById(int carrierId)
        {
            return await _carrierReadRepository.GetByIdAsync(carrierId);
            await _carrierWriteRepository.SaveAsync();

        }

        public async Task Update(Carrier carrier)
        {
            _carrierWriteRepository.Update(carrier);
            await _carrierWriteRepository.SaveAsync();
        }
    }
}


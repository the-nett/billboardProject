using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IBillboardTypeService
    {
        Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync();
        Task<BillboardType> GetBillboardTypeByIdAsync(int id);
        Task CreateBillboardTypeAsync(BillboardType billboardType);
        Task UpdateBillboardTypeAsync(BillboardType billboardType);
        Task DeleteBillboardTypeAsync(int id);
    }

    public class BillboardTypeService : IBillboardTypeService
    {
        private readonly IBillboardTypeRepository _billboardTypeRepository;

        public BillboardTypeService(IBillboardTypeRepository billboardTypeRepository)
        {
            _billboardTypeRepository = billboardTypeRepository;
        }

        public async Task CreateBillboardTypeAsync(BillboardType billboardType)
        {
            await _billboardTypeRepository.CreateBillboardTypeAsync(billboardType);
        }

        public Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync()
        {
            return _billboardTypeRepository.GetAllBillboardTypesAsync();
        }

        public Task<BillboardType> GetBillboardTypeByIdAsync(int id)
        {
            return _billboardTypeRepository.GetBillboardTypeByIdAsync(id);
        }

        public async Task UpdateBillboardTypeAsync(BillboardType billboardType)
        {
            await _billboardTypeRepository.UpdateBillboardTypeAsync(billboardType);
        }

        public async Task DeleteBillboardTypeAsync(int id)
        {
            await _billboardTypeRepository.DeleteBillboardTypeAsync(id);
        }
    }
}

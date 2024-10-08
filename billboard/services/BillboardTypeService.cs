using billboard.Model;
using billboard.Repositories;
using System.Reflection.Metadata;

namespace billboard.services
{
    public interface IBillboardTypeService
    {
        Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync();
        Task<BillboardType> GetBillboardTypeByIdAsync(int id);
        Task CreateBillboardTypeAsync(BillboardType billboardType);
        Task UpdateBillboardTypeAsync(BillboardType billboardType);
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

        public Task UpdateBillboardTypeAsync(BillboardType billboardType)
        {
            throw new NotImplementedException();
        }
    }
}

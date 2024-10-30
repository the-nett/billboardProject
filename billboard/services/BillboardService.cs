using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IBillboardService
    {
        Task<ICollection<Billboard>> GetAllBillboardsAsync();
        Task<Billboard> GetBillboardByIdAsync(int id);
        Task<Billboard> CreateBillboardAsync (Billboard billboard);
        Task<Billboard> UpdateBillboardAsync(Billboard billboard);
        Task DeleteBillboardAsync(int id);
    }

    public class BillboardService : IBillboardService
    {
        private readonly IBillboardRepository _billboardRepository;
        public BillboardService(IBillboardRepository billboardRepository)
        {
            _billboardRepository = billboardRepository;
        }

        public async Task<Billboard> CreateBillboardAsync(Billboard billboard)
        {
           return await _billboardRepository.CreateBillboardAsync(billboard);
        }

        public Task<ICollection<Billboard>> GetAllBillboardsAsync()
        {
            return _billboardRepository.GetAllBillboardsAsync();
        }

        public Task<Billboard> GetBillboardByIdAsync(int id)
        {
            return _billboardRepository.GetBillboardByIdAsync(id);
        }

        public async Task<Billboard> UpdateBillboardAsync (Billboard billboard)
        {
            return await _billboardRepository.UpdateBillboardAsync(billboard);
        }

        public async Task DeleteBillboardAsync(int id)
        {
            await _billboardRepository.DeleteBillboardAsync(id);
        }
    }

}

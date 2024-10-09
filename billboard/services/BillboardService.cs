using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IBillboardService
    {
        Task<IEnumerable<Billboard>> GetAllBillboardsAsync();
        Task<Billboard> GetBillboardByIdAsync(int id);
        Task CreateBillboardAsync(Billboard billboard);
        Task UpdateBillboardAsync(Billboard billboard);
        Task DeleteBillboardAsync(int id);
    }

    public class BillboardService : IBillboardService
    {
        private readonly IBillboardRepository _billboardRepository;
        public BillboardService(IBillboardRepository billboardRepository)
        {
            _billboardRepository = billboardRepository;
        }

        public async Task CreateBillboardAsync(Billboard billboard)
        {
            await _billboardRepository.CreateBillboardAsync(billboard);
        }

        public Task<IEnumerable<Billboard>> GetAllBillboardsAsync()
        {
            return _billboardRepository.GetAllBillboardsAsync();
        }

        public Task<Billboard> GetBillboardByIdAsync(int id)
        {
            return _billboardRepository.GetBillboardByIdAsync(id);
        }

        public async Task UpdateBillboardAsync(Billboard billboard)
        {
            await _billboardRepository.UpdateBillboardAsync(billboard);
        }

        public async Task DeleteBillboardAsync(int id)
        {
            await _billboardRepository.DeleteBillboardAsync(id);
        }
    }

}

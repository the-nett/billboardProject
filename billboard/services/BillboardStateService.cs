using billboard.Model;
using billboard.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Services
{
    public interface IBillboardStateService
    {
        Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync();
        Task<BillboardState> GetBillboardStateByIdAsync(int id);
        Task CreateBillboardStateAsync(BillboardState billboardState);
        Task UpdateBillboardStateAsync(BillboardState billboardState);
        Task DeleteBillboardStateAsync(int id);
    }

    public class BillboardStateService : IBillboardStateService
    {
        private readonly IBillboardStateRepository _billboardStateRepository;

        public BillboardStateService(IBillboardStateRepository billboardStateRepository)
        {
            _billboardStateRepository = billboardStateRepository;
        }

        public async Task CreateBillboardStateAsync(BillboardState billboardState)
        {
            await _billboardStateRepository.CreateBillboardStateAsync(billboardState);
        }

        public Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync()
        {
            return _billboardStateRepository.GetAllBillboardStatesAsync();
        }

        public Task<BillboardState> GetBillboardStateByIdAsync(int id)
        {
            return _billboardStateRepository.GetBillboardStateByIdAsync(id);
        }

        public async Task UpdateBillboardStateAsync(BillboardState billboardState)
        {
            await _billboardStateRepository.UpdateBillboardStateAsync(billboardState);
        }

        public async Task DeleteBillboardStateAsync(int id)
        {
            await _billboardStateRepository.DeleteBillboardStateAsync(id);
        }
    }
}

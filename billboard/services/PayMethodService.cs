using billboard.Model;
using billboard.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.services
{
    public interface IPayMethodService
    {
        Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync();
        Task<PayMethods> GetPayMethodByIdAsync(int id);
        Task CreatePayMethodAsync(PayMethods paymethods);
        Task UpdatePayMethodAsync(PayMethods paymethods);
        Task DeletePayMethodAsync(int id);
    }

    public class PayMethodService : IPayMethodService
    {
        private readonly IPayMethodRepository _payMethodRepository;
        public PayMethodService(IPayMethodRepository payMethodRepository)
        {
            _payMethodRepository = payMethodRepository;
        }

        public async Task CreatePayMethodAsync(PayMethods paymethods)
        {
            await _payMethodRepository.CreatePayMethodAsync(paymethods);
        }

        public Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync()
        {
            return _payMethodRepository.GetAllPayMethodsAsync();
        }

        public Task<PayMethods> GetPayMethodByIdAsync(int id)
        {
            return _payMethodRepository.GetPayMethodByIdAsync(id);
        }

        public async Task UpdatePayMethodAsync(PayMethods paymethods)
        {
            await _payMethodRepository.UpdatePayMethodAsync(paymethods);
        }

        public async Task DeletePayMethodAsync(int id)
        {
            await _payMethodRepository.DeletePayMethodAsync(id);
        }
    }
}

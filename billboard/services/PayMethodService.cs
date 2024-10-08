using billboard.Model;
using billboard.Repositories;
using System.Reflection.Metadata;

namespace billboard.services
{
    public interface IPayMethodService
    {
        Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync();
        Task<PayMethods> GetPayMethodByIdAsync(int id);
        Task CreatePayMethodAsync(PayMethods paymethods);
        Task UpdatePayMethodAsync(PayMethods paymethods);
    }

    public class PayMethodService : IPayMethodService
    {
        private readonly IPayMethodRepository _paymethodRepository;
        public PayMethodService(IPayMethodRepository paymethodRepository)
        {
            _paymethodRepository = paymethodRepository;
        }

        public async Task CreatePayMethodAsync(PayMethods paymethods)
        {
            await _paymethodRepository.CreatePayMethodAsync(paymethods);
        }

        public Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync()
        {
            return _paymethodRepository.GetAllPayMethodsAsync();
        }

        public Task<PayMethods> GetPayMethodByIdAsync(int id)
        {
            return _paymethodRepository.GetPayMethodByIdAsync(id);
        }

        public Task UpdatePayMethodAsync(PayMethods paymethods)
        {
            throw new NotImplementedException();
        }
    }
}

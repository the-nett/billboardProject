using billboard.Model;
using billboard.Repositories;
using System.Reflection.Metadata;

namespace billboard.services
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAllTenantsAsync();
        Task<Tenant> GetTenantByIdAsync(int id);
        Task CreateTenantAsync(Tenant tenant);
        Task UpdateTenantAsync(Tenant tenant);
    }

    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task CreateTenantAsync(Tenant tenant)
        {
            await _tenantRepository.CreateTenantAsync(tenant);
        }

        public Task<IEnumerable<Tenant>> GetAllTenantsAsync()
        {
            return _tenantRepository.GetAllTenantsAsync();
        }

        public Task<Tenant> GetTenantByIdAsync(int id)
        {
            return _tenantRepository.GetTenantByIdAsync(id);
        }

        public Task UpdateTenantAsync(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}

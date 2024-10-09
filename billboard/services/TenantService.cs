using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAllTenantsAsync();
        Task<Tenant> GetTenantByIdAsync(int id);
        Task CreateTenantAsync(Tenant tenant);
        Task UpdateTenantAsync(Tenant tenant);
        Task DeleteTenantAsync(int id);
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

        public async Task UpdateTenantAsync(Tenant tenant)
        {
            await _tenantRepository.UpdateTenantAsync(tenant);
        }

        public async Task DeleteTenantAsync(int id)
        {
            await _tenantRepository.DeleteTenantAsync(id);
        }
    }
}

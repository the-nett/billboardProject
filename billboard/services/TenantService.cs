using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface ITenantService
    {
        Task<ICollection<Tenant>> GetAllTenantsAsync();
        Task<Tenant> GetTenantByIdAsync(int id);
        Task<Tenant> CreateTenantAsync(Tenant tenant);
        Task<Tenant> UpdateTenantAsync(Tenant tenant);
        Task DeleteTenantAsync(int id);
    }

    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<Tenant> CreateTenantAsync(Tenant tenant)
        {
            return await _tenantRepository.CreateTenantAsync(tenant);
        }

        public Task<ICollection<Tenant>> GetAllTenantsAsync()
        {
            return _tenantRepository.GetAllTenantsAsync();
        }

        public Task<Tenant> GetTenantByIdAsync(int id)
        {
            return _tenantRepository.GetTenantByIdAsync(id);
        }

        public async Task<Tenant> UpdateTenantAsync(Tenant tenant)
        {
           return await _tenantRepository.UpdateTenantAsync(tenant);
        }

        public async Task DeleteTenantAsync(int id)
        {
            await _tenantRepository.DeleteTenantAsync(id);
        }
    }
}

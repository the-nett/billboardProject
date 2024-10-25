using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface ITenantRepository
    {
        Task<ICollection<Tenant>> GetAllTenantsAsync();
        Task<Tenant> GetTenantByIdAsync (int id);
        Task<Tenant> CreateTenantAsync (Tenant tenant);
        Task<Tenant> UpdateTenantAsync (Tenant tenant);
        Task DeleteTenantAsync(int id);
    }

    public class TenantRepository : ITenantRepository
    {
        private readonly BilllboardDBContext _contextTenant;
        public TenantRepository(BilllboardDBContext contextTenant)
        {
            _contextTenant = contextTenant;
        }

        public async Task<Tenant> CreateTenantAsync (Tenant tenant)
        {
            // Agregar el nuevo tenant a la base de datos
            await _contextTenant.Tenants.AddAsync(tenant);

            // Guardar los cambios
            await _contextTenant.SaveChangesAsync();
            return tenant;
        }

        public async Task<ICollection<Tenant>> GetAllTenantsAsync()
        {
            return await _contextTenant.Tenants.ToListAsync();
        }

        public async Task<Tenant> GetTenantByIdAsync(int id)
        {
            return await _contextTenant.Tenants.FindAsync(id);
        }

        public async Task<Tenant> UpdateTenantAsync(Tenant tenant)
        {
            // Current tenant by Id
            var existingTenant = await GetTenantByIdAsync(tenant.IdTenant);

            if (existingTenant != null)
            {
                // Update current tenant
                existingTenant.IdUserType = tenant.IdUserType;
                existingTenant.StateDelete = tenant.StateDelete;

                // Save tenant
                await _contextTenant.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Arrendatario no encontrado");
            }
            return tenant;
        }

        public async Task DeleteTenantAsync(int id)
        {
            // Current tenant by Id
            var currentTenant = await _contextTenant.Tenants.FindAsync(id);

            if (currentTenant != null)
            {
                // Update state delete
                currentTenant.StateDelete = true;

                await _contextTenant.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el arrendatario");
            }
        }
    }
}

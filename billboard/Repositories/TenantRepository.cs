using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetAllTenantsAsync();
        Task<Tenant> GetTenantByIdAsync(int id);
        Task CreateTenantAsync(Tenant tenant);
        Task UpdateTenantAsync(Tenant tenant);
    }

    public class TenantRepository : ITenantRepository
    {
        private readonly BilllboardDBContext _contextTenant;
        public TenantRepository(BilllboardDBContext contextTenant)
        {
            _contextTenant = contextTenant;
        }

        public async Task CreateTenantAsync(Tenant tenant)
        {
            // Agregar el nuevo inquilino a la base de datos
            await _contextTenant.Tenants.AddAsync(tenant);

            // Guardar los cambios
            await _contextTenant.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tenant>> GetAllTenantsAsync()
        {
            return await _contextTenant.Tenants.ToListAsync();
        }

        public async Task<Tenant> GetTenantByIdAsync(int id)
        {
            return await _contextTenant.Tenants.FindAsync(id);
        }

        public async Task UpdateTenantAsync(Tenant tenant)
        {
            var existingTenant = await GetTenantByIdAsync(tenant.IdTenant);

            if (existingTenant != null)
            {
                existingTenant.TenantName = tenant.TenantName;

                await _contextTenant.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Arrendatario no encontrado");
            }
        }
    }
}

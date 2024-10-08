using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
    }

    public class PermissionRepository : IPermissionRepository
    {
        private readonly BilllboardDBContext _contextPermission;
        public PermissionRepository(BilllboardDBContext contextPermission)
        {
            _contextPermission = contextPermission;
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            // Agregar el nuevo permiso a la base de datos
            await _contextPermission.Permissions.AddAsync(permission);

            // Guardar los cambios
            await _contextPermission.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _contextPermission.Permissions.ToListAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _contextPermission.Permissions.FindAsync(id);
        }

        public Task UpdatePermissionAsync(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
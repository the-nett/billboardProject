using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(int id);
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

        public async Task UpdatePermissionAsync(Permission permission)
        {
            // Current permission by Id
            var existingPermission = await GetPermissionByIdAsync(permission.Id_Permission);

            if (existingPermission != null)
            {
                // Update current permission
                existingPermission.Permission_ = permission.Permission_;
                existingPermission.StateDelete = permission.StateDelete;

                // Marcar el permiso como modificado para que Entity Framework lo rastree
                //_contextPermission.Entry(existingPermission).State = EntityState.Modified;
                // Save permission
                await _contextPermission.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Permiso no encontrado");
            }
        }

        public async Task DeletePermissionAsync(int id)
        {
            // Current permission by Id
            var currentPermission = await _contextPermission.Permissions.FindAsync(id);

            if (currentPermission != null)
            {
                // Update state delete
                currentPermission.StateDelete = true;

                await _contextPermission.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el permiso");
            }
        }
    }
}

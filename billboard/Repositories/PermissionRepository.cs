using AutoMapper;
using billboard.Context;
using billboard.Model;
using billboard.Model.Dtos.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IPermissionRepository
    {
        Task<ICollection<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<Permission> CreatePermissionAsync(Permission permission);
        Task<Permission> UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(int id);
    }

    public class PermissionRepository : IPermissionRepository
    {
        private readonly BilllboardDBContext _contextPermission;

        public PermissionRepository(BilllboardDBContext contextPermission)
        {
            _contextPermission = contextPermission;
        }

        public async Task<ICollection<Permission>> GetAllPermissionsAsync()
        {
            return await _contextPermission.Permissions.ToListAsync();
        }
        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _contextPermission.Permissions.FindAsync(id);
        }

        public async Task<Permission> UpdatePermissionAsync(Permission permission)
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
            return permission;
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

        public async Task<Permission> CreatePermissionAsync(Permission permission)
        {
            await _contextPermission.Permissions.AddAsync(permission);
            await _contextPermission.SaveChangesAsync();
            return permission;
        }
    }
}

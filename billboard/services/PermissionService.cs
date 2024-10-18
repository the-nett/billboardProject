using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(int id);
    }

    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            await _permissionRepository.CreatePermissionAsync(permission);
        }

        public Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return _permissionRepository.GetAllPermissionsAsync();
        }

        public Task<Permission> GetPermissionByIdAsync(int id)
        {
            return _permissionRepository.GetPermissionByIdAsync(id);
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            await _permissionRepository.UpdatePermissionAsync(permission);
        }

        public async Task DeletePermissionAsync(int id)
        {
            await _permissionRepository.DeletePermissionAsync(id);
        }
    }
}

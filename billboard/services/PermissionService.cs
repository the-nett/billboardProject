using billboard.Model;
using billboard.Repositories;
using System.Reflection.Metadata;

namespace billboard.services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
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
    }
}

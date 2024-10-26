using billboard.Model;
using billboard.Repositories;
using System.Security;

namespace billboard.services
{
    public interface IUserTypePermissionsService
    {
        Task<ICollection<UserTypePermissions>> GetAllUserTypePermissionsAsync();
        Task<UserTypePermissions> GetUserTypePermissionByIdAsync(int id, int id2);
        Task<UserTypePermissions> CreateUserTypePermissionAsync(UserTypePermissions userTypePermissions);
        Task<UserTypePermissions> UpdateUserTypePermissionAsync(UserTypePermissions userTypePermissions);
        Task DeleteUserTypePermissionAsyncId(int id, int id2);
    }
    public class UserTypePermissionsService : IUserTypePermissionsService
    {
        private readonly IUserTypePermissionsRepository _userTypePermissionsRepository;
        public UserTypePermissionsService(IUserTypePermissionsRepository userTypePermissionsRepository)
        {
            _userTypePermissionsRepository = userTypePermissionsRepository;
        }
        public async Task<UserTypePermissions> CreateUserTypePermissionAsync(UserTypePermissions userTypePermissions)
        {
            return await _userTypePermissionsRepository.CreateUserTypePermissionAsync(userTypePermissions);
        }

        public async Task DeleteUserTypePermissionAsyncId(int id, int id2)
        {
            await _userTypePermissionsRepository.DeleteUserTypePermissionAsyncId(id, id2);
        }

        public async Task<ICollection<UserTypePermissions>> GetAllUserTypePermissionsAsync()
        {
            return await _userTypePermissionsRepository.GetAllUserTypePermissionsAsync();
        }

        public Task<UserTypePermissions> GetUserTypePermissionByIdAsync(int id, int id2)
        {
            return _userTypePermissionsRepository.GetUserTypePermissionByIdAsync(id, id2);
        }

        public async Task<UserTypePermissions> UpdateUserTypePermissionAsync(UserTypePermissions userTypePermissions)
        {
            return await _userTypePermissionsRepository.UpdateUserTypePermissionAsync(userTypePermissions);
        }
    }

}

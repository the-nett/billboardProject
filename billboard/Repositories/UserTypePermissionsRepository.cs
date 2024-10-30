using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace billboard.Repositories
{
    public interface IUserTypePermissionsRepository
    {
        Task<ICollection<UserTypePermissions>> GetAllUserTypePermissionsAsync();
        Task<UserTypePermissions> GetUserTypePermissionByIdAsync(int id, int id2);
        Task<UserTypePermissions> CreateUserTypePermissionAsync(UserTypePermissions userTypePermission);
        Task<UserTypePermissions> UpdateUserTypePermissionAsync(UserTypePermissions userTypePermission);
        Task DeleteUserTypePermissionAsyncId(int id, int id2);
    }

    public class UserTypePermissionsRepository : IUserTypePermissionsRepository
    {
        private readonly BilllboardDBContext _contextUserTypePermissions;

        public UserTypePermissionsRepository(BilllboardDBContext contextUserTypePermissions)
        {
            _contextUserTypePermissions = contextUserTypePermissions;
        }
        public async Task<UserTypePermissions> CreateUserTypePermissionAsync(UserTypePermissions userTypePermission)
        {

            await _contextUserTypePermissions.UserTypePermissions.AddAsync(userTypePermission);
            await _contextUserTypePermissions.SaveChangesAsync();
            return userTypePermission;
        }

        public async Task DeleteUserTypePermissionAsyncId(int id, int id2)
        {
            // Current permission by Id
            var currentPermission = await _contextUserTypePermissions.UserTypePermissions.FindAsync(id, id2);

            if (currentPermission != null)
            {
                // Update state delete
                currentPermission.StateDelete = true;

                await _contextUserTypePermissions.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el el registro");
            }
        }

        public async Task<ICollection<UserTypePermissions>> GetAllUserTypePermissionsAsync()
        {
            return await _contextUserTypePermissions.UserTypePermissions.ToListAsync();
        }

        public async Task<UserTypePermissions> GetUserTypePermissionByIdAsync(int id, int id2)
        {
            return await _contextUserTypePermissions.UserTypePermissions.FindAsync(id, id2);
        }

        public async Task<UserTypePermissions> UpdateUserTypePermissionAsync(UserTypePermissions userTypePermission)
        {
            // Current permission by Id
            var existingUserXPermission = await GetUserTypePermissionByIdAsync(userTypePermission.Id_Usertype, userTypePermission.Id_permission);

            if (existingUserXPermission != null)
            {
                // Update current permission
                existingUserXPermission.StateDelete = existingUserXPermission.StateDelete;

                // Marcar el permiso como modificado para que Entity Framework lo rastree
                //_contextPermission.Entry(existingPermission).State = EntityState.Modified;
                // Save permission
                await _contextUserTypePermissions.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Permiso no encontrado");
            }
            return userTypePermission;
        }
    }
}

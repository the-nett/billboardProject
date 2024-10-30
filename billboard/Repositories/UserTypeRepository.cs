using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security;

namespace billboard.Repositories
{
    public interface IUserTypeRepository
    {
        Task<ICollection<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task<UserType> CreateUserTypeAsync(UserType usertype);
        Task<UserType> UpdateUserTypeAsync(UserType usertype);
        Task DeleteUserTypeAsync(int id);
    }

    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly BilllboardDBContext _contextUserType;
        public UserTypeRepository(BilllboardDBContext contextUserType)
        {
            _contextUserType = contextUserType;
        }

        public async Task<UserType> CreateUserTypeAsync(UserType usertype)
        {
            await _contextUserType.UserTypes.AddAsync(usertype);
            await _contextUserType.SaveChangesAsync();
            return usertype;
        }

        public async Task<ICollection<UserType>> GetAllUserTypesAsync()
        {
            return await _contextUserType.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _contextUserType.UserTypes.FindAsync(id);
        }

        public async Task<UserType> UpdateUserTypeAsync(UserType usertype)
        {
            // Current utype by Id
            var existingUsertype = await GetUserTypeByIdAsync(usertype.Id_Usertype);

            if (existingUsertype != null)
            {
                // Update current utype
                existingUsertype.Utype = usertype.Utype;
                existingUsertype.StateDelete = usertype.StateDelete;

                await _contextUserType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Tipo de usuario no encontrado");
            }
            return usertype;
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            // Current UserType by Id
            var currentUserType = await _contextUserType.UserTypes.FindAsync(id);

            if (currentUserType != null)
            {
                // Update state delete
                currentUserType.StateDelete = true;

                await _contextUserType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el Tipo de Usuario");
            }
        }
    }
}

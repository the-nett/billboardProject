using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType usertype);
        Task UpdateUserTypeAsync(UserType usertype);
        Task DeleteUserTypeAsync(int id);
    }

    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly BilllboardDBContext _contextUserType;
        public UserTypeRepository(BilllboardDBContext contextUserType)
        {
            _contextUserType = contextUserType;
        }

        public async Task CreateUserTypeAsync(UserType usertype)
        {
            // Agregar el nuevo UserType a la base de datos
            await _contextUserType.UserTypes.AddAsync(usertype);

            // Guardar los cambios
            await _contextUserType.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return await _contextUserType.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _contextUserType.UserTypes.FindAsync(id);
        }

        public async Task UpdateUserTypeAsync(UserType usertype)
        {
            // Current UserType by Id
            var existingUserType = await GetUserTypeByIdAsync(usertype.Id_Usertype);

            if (existingUserType != null)
            {
                // Update current UserType
                existingUserType.Utype = usertype.Utype;
                existingUserType.StateDelete = usertype.StateDelete;

                // Marcar el UserType como modificado para que Entity Framework lo rastree
                //_contextUserType.Entry(existingUserType).State = EntityState.Modified;
                // Save UserType
                await _contextUserType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Tipo de Usuario no encontrado");
            }
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

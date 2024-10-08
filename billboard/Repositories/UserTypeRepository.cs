using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType usertype);
        Task UpdateUserTypeAsync(UserType usertype);
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
            // Agregar el nuevo ciudad a la base de datos
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

        public async Task UpdateUserTypeAsync(UserType userType)
        {
            var existingUserType = await GetUserTypeByIdAsync(userType.Id_Usertype);

            if (existingUserType != null)
            {
                existingUserType.UserTypeName = userType.UserTypeName;

                await _contextUserType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Tipo de usuario no encontrado");
            }
        }
    }
}
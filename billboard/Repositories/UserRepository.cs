using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly BilllboardDBContext _contextUser;
        public UserRepository(BilllboardDBContext contextUser)
        {
            _contextUser = contextUser;
        }

        public async Task CreateUserAsync(User user)
        {
            // Agregar el nuevo usuario a la base de datos
            await _contextUser.Users.AddAsync(user);

            // Guardar los cambios
            await _contextUser.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _contextUser.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _contextUser.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await GetUserByIdAsync(user.IdUser);

            if (existingUser != null)
            {
                existingUser.IdUser = user.IdUser;
                existingUser.StateDelete = user.StateDelete;

                await _contextUser.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            // Current user by Id
            var currentUser = await _contextUser.Users.FindAsync(id);

            if (currentUser != null)
            {
                //Update state delete
                currentUser.StateDelete = true;

                await _contextUser.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el usuario");
            }
        }
    }
}

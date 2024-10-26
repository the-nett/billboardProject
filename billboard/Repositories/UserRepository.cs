using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly BilllboardDBContext _contextUser;

        public UserRepository(BilllboardDBContext contextUser)
        {
            _contextUser = contextUser;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.IdUserType = 1;
            user.Date = DateTime.Now;
            user.PeopleSalt = GenerateRandomSalt(10); // Generar una cadena aleatoria de 10 caracteres

            // Agregar el nuevo usuario a la base de datos
            await _contextUser.Users.AddAsync(user);

            // Guardar los cambios
            await _contextUser.SaveChangesAsync();
            return user;
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _contextUser.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _contextUser.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            // Busca el usuario existente por su ID
            var existingUser = await GetUserByIdAsync(user.IdUser);

            if (existingUser != null)
            {
                // Actualiza las propiedades necesarias
                existingUser.PeoplePassword = user.PeoplePassword;
                existingUser.IdUserType = user.IdUserType;
                existingUser.Date = DateTime.Now;
                existingUser.StateDelete = user.StateDelete;

                // Guarda los cambios
                await _contextUser.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }

            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            // Buscar usuario por su ID
            var currentUser = await _contextUser.Users.FindAsync(id);

            if (currentUser != null)
            {
                // Marcar el estado de eliminación
                currentUser.StateDelete = true;

                await _contextUser.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el usuario");
            }
        }

        // Método para generar una cadena aleatoria de salt
        private static string GenerateRandomSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

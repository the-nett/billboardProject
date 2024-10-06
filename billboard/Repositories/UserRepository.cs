using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace billboard.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly BilllboardDBContext _context;
        public UserRepository(BilllboardDBContext context)
        {
            _context = context;
        }
        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<User>> GetAllsubjectsAsync()
=======
        public async Task<IEnumerable<User>> GetAllUsersAsync()
>>>>>>> Dev-Felipe
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            _context.SaveChangesAsync();
        }
    }
}

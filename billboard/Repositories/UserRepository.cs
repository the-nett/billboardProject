using billboard.Context;
using billboard.Model;
using billboard.Model.Dtos;
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
        //Task<AnswerUserLoginDto> Login(User userLoginDto);
        //Task<DataUserDto> Register(User userRegisterDto);
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

        public async Task<IEnumerable<User>> GetAllUsersAsync()

        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //public Task<AnswerUserLoginDto> Login(User userLoginDto)
        //{
          //  throw new NotImplementedException();
        //}

        //public Task<DataUserDto> Register(RegisterNaturalPersonDto registerNaturalPersonDto)
       // {
            //var encryptedPassword = Obtainmd5(registerNaturalPersonDto.PeoplePassword);

            //User user = new User()
           // {
                //Name = registerNaturalPersonDto.Name,

         //   };
       // }

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

using billboard.Model;
using billboard.Repositories;
using System.Reflection.Metadata;

namespace billboard.services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType usertype);
        Task UpdateUserTypeAsync(UserType usertype);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _usertypeRepository;
        public UserTypeService(IUserTypeRepository usertypeRepository)
        {
            _usertypeRepository = usertypeRepository;
        }

        public async Task CreateUserTypeAsync(UserType usertype)
        {
            await _usertypeRepository.CreateUserTypeAsync(usertype);
        }

        public Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return _usertypeRepository.GetAllUserTypesAsync();
        }

        public Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return _usertypeRepository.GetUserTypeByIdAsync(id);
        }

        public Task UpdateUserTypeAsync(UserType usertype)
        {
            throw new NotImplementedException();
        }
    }
}

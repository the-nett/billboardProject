using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType usertype);
        Task UpdateUserTypeAsync(UserType usertype);
        Task DeleteUserTypeAsync(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task CreateUserTypeAsync(UserType usertype)
        {
            await _userTypeRepository.CreateUserTypeAsync(usertype);
        }

        public Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return _userTypeRepository.GetAllUserTypesAsync();
        }

        public Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return _userTypeRepository.GetUserTypeByIdAsync(id);
        }

        public async Task UpdateUserTypeAsync(UserType usertype)
        {
            await _userTypeRepository.UpdateUserTypeAsync(usertype);
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            await _userTypeRepository.DeleteUserTypeAsync(id);
        }
    }
}

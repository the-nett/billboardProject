using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IUserTypeService
    {
        Task<ICollection<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task<UserType> CreateUserTypeAsync(UserType usertype);
        Task<UserType> UpdateUserTypeAsync(UserType usertype);
        Task DeleteUserTypeAsync(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<UserType> CreateUserTypeAsync(UserType usertype)
        {
            return await _userTypeRepository.CreateUserTypeAsync(usertype);
        }

        public async Task<ICollection<UserType>> GetAllUserTypesAsync()
        {
            return await _userTypeRepository.GetAllUserTypesAsync();
        }

        public Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return _userTypeRepository.GetUserTypeByIdAsync(id);
        }

        public async Task<UserType> UpdateUserTypeAsync(UserType usertype)
        {
           return await _userTypeRepository.UpdateUserTypeAsync(usertype);
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            await _userTypeRepository.DeleteUserTypeAsync(id);
        }
    }
}

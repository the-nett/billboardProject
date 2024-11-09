using billboard.Model;
using billboard.Model.Dtos.NaturalPerson;
using billboard.Repositories;
using static billboard.Repositories.UserRepository;

namespace billboard.Services
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<AnswerLogInNaturalPerson> Login(LogInNaturalPerson logInNaturalPerson);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserHistoriesRepository _UserHistoriesRepository;

        public UserService(IUserRepository userRepository, IUserHistoriesRepository userHistoriesRepository)
        {
            _userRepository = userRepository;
            _UserHistoriesRepository = userHistoriesRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);    
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            // Seteamos para llenar la tabla de auditoría
            var existingUser = await GetUserByIdAsync(user.IdUser);
            if (existingUser != null)
            {
                // Crear el objeto UserHistory
                var userHistory = new UserHistory
                {
                    IdUser = existingUser.IdUser,
                    PeopleId = existingUser.PeopleId,
                    PeoplePassword = existingUser.PeoplePassword,
                    PeopleSalt = existingUser.PeopleSalt,
                    IdUserType = existingUser.IdUserType,
                    StateDelete = existingUser.StateDelete,
                    ModifyByPerson = idPeopleLogIn, // Aquí asignas el ID de la persona que realizó la modificación
                    Modified = DateTime.Now
                };

                // Llamar al repositorio para crear el historial de usuario
                await _UserHistoriesRepository.CreateUserHistorAsync(userHistory);
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }

            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var currentUser = await _userRepository.GetUserByIdAsync(id);
            // Crear el objeto UserHistory
            var userHistory = new UserHistory
            {
                IdUser = currentUser.IdUser,
                PeopleId = currentUser.PeopleId,
                PeoplePassword = currentUser.PeoplePassword,
                PeopleSalt = currentUser.PeopleSalt,
                IdUserType = currentUser.IdUserType,
                StateDelete = currentUser.StateDelete,
                ModifyByPerson = idPeopleLogIn, // Aquí asignas el ID de la persona que realizó la modificación
                Modified = DateTime.Now
            };

            // Llamar al repositorio para crear el historial de usuario
            await _UserHistoriesRepository.CreateUserHistorAsync(userHistory);
            await _userRepository.DeleteUserAsync(id);
        }
        public async Task<AnswerLogInNaturalPerson> Login(LogInNaturalPerson logInNaturalPerson)
        {
            return await _userRepository.Login(logInNaturalPerson);
        }
    }

}

using billboard.Model;
using billboard.Repositories;
using billboard.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace billboard.services
{
    public interface IGameService
    {
        Task<ICollection<Game>> GetAllGameAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> GetGameByIdUser(int id);
        Task<Game> CreateGameAsync(Game game);
        Task<Game> UpdateGameAsync(Game game);
    }
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            return await _gameRepository.CreateGameAsync(game);
        }

        public Task<ICollection<Game>> GetAllGameAsync()
        {
            return _gameRepository.GetAllGameAsync();
        }

        public Task<Game> GetGameByIdAsync(int id)
        {
            return _gameRepository.GetGameByIdAsync(id);
        }

        public Task<Game> GetGameByIdUser(int id)
        {
            return _gameRepository.GetGameByIdUser(id);
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            return await _gameRepository.UpdateGameAsync(game);
        }
    }
}

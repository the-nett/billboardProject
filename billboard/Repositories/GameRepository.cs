using billboard.Model.Dtos.Company;
using billboard.Model;
using billboard.Context;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace billboard.Repositories
{
    
    // Interface for Game methods
    public interface IGameRepository
    {
        Task<ICollection<Game>> GetAllGameAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> CreateGameAsync(Game game);
        Task<Game> UpdateGameAsync(Game game);
    }

    public class GameRepository : IGameRepository
    {
        private readonly BilllboardDBContext _contextGame;
        private string secretKey;
        public GameRepository (BilllboardDBContext contextgame)
        {
            _contextGame = contextgame;
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            await _contextGame.Games.AddAsync(game);
            await _contextGame.SaveChangesAsync();
            return game;
        }

        public async Task<ICollection<Game>> GetAllGameAsync()
        {
            return await _contextGame.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _contextGame.Games.FindAsync(id);
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            // Obtener la partida actual por Id
            var existingGame = await GetGameByIdAsync(game.IdGame);

            if (existingGame != null)
            {
                // Actualizar la compañía actual
                existingGame.LevelTime = game.LevelTime;
                existingGame.Level = game.Level;

                // Guardar los cambios
                await _contextGame.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Partida no encontrada");
            }
            return game;
        }
    }
}

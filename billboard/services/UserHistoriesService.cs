using billboard.Model;
using billboard.Repositories;

namespace billboard.services
{
    public interface IUserHistoriesService
    {
        Task<IEnumerable<UserHistory>> GetAlUserHistoriesAsync();
        //Task<City> GetCityByIdAsync(int id);
        //Task CreateCityAsync(City city);
  
    }
    public class UserHistoriesService : IUserHistoriesService
    {
        private readonly IUserHistoriesRepository _UserHistoriesRepository;
        public UserHistoriesService(IUserHistoriesRepository userHistoriesRepository)
        {
            _UserHistoriesRepository = userHistoriesRepository;
        }
        public Task<IEnumerable<UserHistory>> GetAlUserHistoriesAsync()
        {
            return _UserHistoriesRepository.GetAlUserHistoriesAsync();
        }
    }
}

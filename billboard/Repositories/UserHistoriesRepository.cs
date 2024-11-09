using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;

namespace billboard.Repositories
{
    public interface IUserHistoriesRepository
    {
        Task<IEnumerable<UserHistory>> GetAlUserHistoriesAsync();
        //Task<City> GetCityByIdAsync(int id);
        Task <UserHistory> CreateUserHistorAsync(UserHistory userHistory);
    }
        public class UserHistoriesRepository : IUserHistoriesRepository
        {
            private readonly BilllboardDBContext _contextUserHIstories;
            public UserHistoriesRepository(BilllboardDBContext contextUserHIstories)
            {
                _contextUserHIstories = contextUserHIstories;
            }
            public async Task <UserHistory> CreateUserHistorAsync(UserHistory userHistory)
            {
            

                await _contextUserHIstories.UserHistories.AddAsync(userHistory);

                // Guardar los cambios
                await _contextUserHIstories.SaveChangesAsync();
                 return userHistory;
            }

            public async Task<IEnumerable<UserHistory>> GetAlUserHistoriesAsync()
            {
                    return await _contextUserHIstories.UserHistories.ToListAsync();
                }
            }
    }

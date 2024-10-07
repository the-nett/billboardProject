using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task CreateCityAsync(City city);
        Task UpdateCityAsync(City city);
    }

    public class CityRepository : ICityRepository
    {
        private readonly BilllboardDBContext _contextCity;
        public CityRepository(BilllboardDBContext contextCity)
        {
            _contextCity = contextCity;
        }

        public async Task CreateCityAsync(City city)
        {
            // Add
            await _contextCity.Cities.AddAsync(city);

            // save
            await _contextCity.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _contextCity.Cities.ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _contextCity.Cities.FindAsync(id);
        }

        public async Task UpdateCityAsync(City city)
        {
            // Current document by Id
            var existingcity = await GetCityByIdAsync(city.CityId);

            if (existingcity != null)
            {
                //Update current city
                existingcity.CityName = city.CityName;

                // Marcar el documento como modificado para que Entity Framework lo rastree
                //_contextDocument.Entry(existingDocument).State = EntityState.Modified;
                // Save city
                await _contextCity.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Ciudad no encontrada");
            }
        }
    }
}
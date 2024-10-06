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
            // Agregar el nuevo ciudad a la base de datos
            await _contextCity.Cities.AddAsync(city);

            // Guardar los cambios
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

        public Task UpdateCityAsync(City city)
        {
            throw new NotImplementedException();
        }
    }
}
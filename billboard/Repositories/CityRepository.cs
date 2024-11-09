using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;

namespace billboard.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task CreateCityAsync(City city);
        Task UpdateCityAsync(City city);
        Task DeleteCityAsync(int id);
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
            // Agregar la nueva ciudad a la base de datos
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

        public async Task UpdateCityAsync(City city)
        {
            // Ciudad actual por Id
            var existingCity = await GetCityByIdAsync(city.CityId);

            if (existingCity != null)
            {
                // Actualizar ciudad actual
                existingCity.CityName = city.CityName;
                existingCity.StateDelete = city.StateDelete;

                // Guardar ciudad
                await _contextCity.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Ciudad no encontrada");
            }
        }

        public async Task DeleteCityAsync(int id)
        {
            // Ciudad actual por Id
            var currentCity = await _contextCity.Cities.FindAsync(id);

            if (currentCity != null)
            {
                // Actualizar estado de eliminación
                currentCity.StateDelete = true;

                await _contextCity.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar la ciudad");
            }
        }
    }
}

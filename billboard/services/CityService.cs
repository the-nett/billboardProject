﻿using billboard.Model;
using billboard.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task CreateCityAsync(City city);
        Task UpdateCityAsync(City city);
    }

    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task CreateCityAsync(City city)
        {
            await _cityRepository.CreateCityAsync(city);
        }

        public Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return _cityRepository.GetAllCitiesAsync();
        }

        public Task<City> GetCityByIdAsync(int id)
        {
            return _cityRepository.GetCityByIdAsync(id);
        }

        public async Task UpdateCityAsync(City city)
        {
            await _cityRepository.UpdateCityAsync(city);
        }
    }
}
﻿using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface ILessorService
    {
        Task<IEnumerable<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync(int id);
        Task CreateLessorAsync(Lessor lessor);
        Task UpdateLessorAsync(Lessor lessor);
        Task DeleteLessorAsync(int id);
    }

    public class LessorService : ILessorService
    {
        private readonly ILessorRepository _lessorRepository;
        public LessorService(ILessorRepository lessorRepository)
        {
            _lessorRepository = lessorRepository;
        }

        public async Task CreateLessorAsync(Lessor lessor)
        {
            await _lessorRepository.CreateLessorAsync(lessor);
        }

        public Task<IEnumerable<Lessor>> GetAllLessorsAsync()
        {
            return _lessorRepository.GetAllLessorsAsync();
        }

        public Task<Lessor> GetLessorByIdAsync(int id)
        {
            return _lessorRepository.GetLessorByIdAsync(id);
        }

        public async Task UpdateLessorAsync(Lessor lessor)
        {
            await _lessorRepository.UpdateLessorAsync(lessor);
        }

        public async Task DeleteLessorAsync(int id)
        {
            await _lessorRepository.DeleteLessorAsync(id);
        }
    }
}


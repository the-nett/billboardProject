using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface ILessorService
    {
        Task<ICollection<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync (int id);
        Task<Lessor> CreateLessorAsync (Lessor lessor);
        Task<Lessor> UpdateLessorAsync (Lessor lessor);
        Task DeleteLessorAsync (int id);
    }

    public class LessorService : ILessorService
    {
        private readonly ILessorRepository _lessorRepository;
        public LessorService(ILessorRepository lessorRepository)
        {
            _lessorRepository = lessorRepository;
        }

        public async Task<Lessor> CreateLessorAsync(Lessor lessor)
        {
            return await _lessorRepository.CreateLessorAsync(lessor);
        }

        public async Task<ICollection<Lessor>> GetAllLessorsAsync()
        {
            return await _lessorRepository.GetAllLessorsAsync();
        }

        public Task<Lessor> GetLessorByIdAsync(int id)
        {
            return _lessorRepository.GetLessorByIdAsync(id);
        }

        public async Task<Lessor> UpdateLessorAsync(Lessor lessor)
        {
            return await _lessorRepository.UpdateLessorAsync(lessor);
        }

        public async Task DeleteLessorAsync(int id)
        {
            await _lessorRepository.DeleteLessorAsync(id);
        }
    }
}


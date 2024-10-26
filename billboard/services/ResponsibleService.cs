using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IResponsibleService
    {
        Task<IEnumerable<Responsible>> GetAllResponsiblesAsync();
        Task<Responsible> GetResponsibleByIdAsync(int id);
        Task CreateResponsibleAsync(Responsible responsible);
        Task UpdateResponsibleAsync(Responsible responsible);
        Task DeleteResponsibleAsync(int id);
    }

    public class ResponsibleService : IResponsibleService
    {
        private readonly IResponsibleRepository _responsibleRepository;
        public ResponsibleService(IResponsibleRepository responsibleRepository)
        {
            _responsibleRepository = responsibleRepository;
        }

        public async Task CreateResponsibleAsync(Responsible responsible)
        {
            await _responsibleRepository.CreateResponsibleAsync(responsible);
        }

        public Task<IEnumerable<Responsible>> GetAllResponsiblesAsync()
        {
            return _responsibleRepository.GetAllResponsiblesAsync();
        }

        public Task<Responsible> GetResponsibleByIdAsync(int id)
        {
            return _responsibleRepository.GetResponsibleByIdAsync(id);
        }

        public async Task UpdateResponsibleAsync(Responsible responsible)
        {
            await _responsibleRepository.UpdateResponsibleAsync(responsible);
        }

        public async Task DeleteResponsibleAsync(int id)
        {
            await _responsibleRepository.DeleteResponsibleAsync(id);
        }
    }
}

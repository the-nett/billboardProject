using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IIndustryService
    {
        Task<IEnumerable<Industry>> GetAllIndustriesAsync();
        Task<Industry> GetIndustryByIdAsync(int id);
        Task CreateIndustryAsync(Industry industry);
        Task UpdateIndustryAsync(Industry industry);
        Task DeleteIndustryAsync(int id);
    }

    public class IndustryService : IIndustryService
    {
        private readonly IIndustryRepository _industryRepository;
        public IndustryService(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public async Task CreateIndustryAsync(Industry industry)
        {
            await _industryRepository.CreateIndustryAsync(industry);
        }

        public Task<IEnumerable<Industry>> GetAllIndustriesAsync()
        {
            return _industryRepository.GetAllIndustriesAsync();
        }

        public Task<Industry> GetIndustryByIdAsync(int id)
        {
            return _industryRepository.GetIndustryByIdAsync(id);
        }

        public async Task UpdateIndustryAsync(Industry industry)
        {
            await _industryRepository.UpdateIndustryAsync(industry);
        }

        public async Task DeleteIndustryAsync(int id)
        {
            await _industryRepository.DeleteIndustryAsync(id);
        }
    }
}

using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface IIndustryRepository
    {
        Task<IEnumerable<Industry>> GetAllIndustriesAsync();
        Task<Industry> GetIndustryByIdAsync(int id);
        Task CreateIndustryAsync(Industry industry);
        Task UpdateIndustryAsync(Industry industry);
    }
    
    public class IndustryRepository : IIndustryRepository
    {
        private readonly BilllboardDBContext _contextIndustry;
        public IndustryRepository(BilllboardDBContext contextIndustry)
        {
            _contextIndustry = contextIndustry;
        }
        
        public async Task CreateIndustryAsync(Industry industry)
        {
            // Agregar la nueva industria a la base de datos
            await _contextIndustry.Industries.AddAsync(industry);
            
            // Guardar los cambios
            await _contextIndustry.SaveChangesAsync();
            }
        
        public async Task<IEnumerable<Industry>> GetAllIndustriesAsync()
        {
            return await _contextIndustry.Industries.ToListAsync();
        }
        
        public async Task<Industry> GetIndustryByIdAsync(int id)
        {
            return await _contextIndustry.Industries.FindAsync(id);
        }

        public async Task UpdateIndustryAsync(Industry industry)
        {
            var existingIndustry = await GetIndustryByIdAsync(industry.IndustryId);

            if (existingIndustry != null)
            {
                existingIndustry.IndustryName = industry.IndustryName;

                await _contextIndustry.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Industria no encontrada");
            }
        }

    }
}

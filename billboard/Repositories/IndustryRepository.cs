using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IIndustryRepository
    {
        Task<IEnumerable<Industry>> GetAllIndustriesAsync();
        Task<Industry> GetIndustryByIdAsync(int id);
        Task CreateIndustryAsync(Industry industry);
        Task UpdateIndustryAsync(Industry industry);
        Task DeleteIndustryAsync(int id);
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
            // Current industry by Id
            var existingIndustry = await GetIndustryByIdAsync(industry.IndustryId);

            if (existingIndustry != null)
            {
                // Update current industry
                existingIndustry.IndustryName = industry.IndustryName;
                existingIndustry.StateDelete = industry.StateDelete;

                // Marcar la industria como modificada para que Entity Framework lo rastree
                //_contextIndustry.Entry(existingIndustry).State = EntityState.Modified;
                // Guardar la industria
                await _contextIndustry.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Industria no encontrada");
            }
        }

        public async Task DeleteIndustryAsync(int id)
        {
            // Current industry by Id
            var currentIndustry = await _contextIndustry.Industries.FindAsync(id);

            if (currentIndustry != null)
            {
                // Update state delete
                currentIndustry.StateDelete = true;

                await _contextIndustry.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar la industria");
            }
        }
    }
}

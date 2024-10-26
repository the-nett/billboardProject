using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IResponsibleRepository
    {
        Task<IEnumerable<Responsible>> GetAllResponsiblesAsync();
        Task<Responsible> GetResponsibleByIdAsync(int id);
        Task CreateResponsibleAsync(Responsible responsible);
        Task UpdateResponsibleAsync(Responsible responsible);
        Task DeleteResponsibleAsync(int id);
    }

    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly BilllboardDBContext _contextResponsible;
        public ResponsibleRepository(BilllboardDBContext contextResponsible)
        {
            _contextResponsible = contextResponsible;
        }

        public async Task CreateResponsibleAsync(Responsible responsible)
        {
            // Agregar el nuevo responsable a la base de datos
            await _contextResponsible.Responsibles.AddAsync(responsible);

            // Guardar los cambios
            await _contextResponsible.SaveChangesAsync();
        }

        public async Task<IEnumerable<Responsible>> GetAllResponsiblesAsync()
        {
            return await _contextResponsible.Responsibles.ToListAsync();
        }

        public async Task<Responsible> GetResponsibleByIdAsync(int id)
        {
            return await _contextResponsible.Responsibles.FindAsync(id);
        }

        public async Task UpdateResponsibleAsync(Responsible responsible)
        {
            // Current responsible by Id
            var existingResponsible = await GetResponsibleByIdAsync(responsible.IdResponsible);

            if (existingResponsible != null)
            {
                // Update current responsible
                existingResponsible.IdResponsible = responsible.IdResponsible;
                existingResponsible.StateDelete = responsible.StateDelete;

                // Marcar el responsable como modificado para que Entity Framework lo rastree
                //_contextResponsible.Entry(existingResponsible).State = EntityState.Modified;
                // Save responsible
                await _contextResponsible.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Responsable no encontrado");
            }
        }

        public async Task DeleteResponsibleAsync(int id)
        {
            // Current responsible by Id
            var currentResponsible = await _contextResponsible.Responsibles.FindAsync(id);

            if (currentResponsible != null)
            {
                // Update state delete
                currentResponsible.StateDelete = true;

                await _contextResponsible.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el responsable");
            }
        }
    }
}

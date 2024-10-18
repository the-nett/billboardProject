using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface ILessorRepository
    {
        Task<IEnumerable<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync(int id);
        Task CreateLessorAsync(Lessor lessor);
        Task UpdateLessorAsync(Lessor lessor);
        Task DeleteLessorAsync(int id);
    }

    public class LessorRepository : ILessorRepository
    {
        private readonly BilllboardDBContext _contextLessor;
        public LessorRepository(BilllboardDBContext contextLessor)
        {
            _contextLessor = contextLessor;
        }

        public async Task CreateLessorAsync(Lessor lessor)
        {
            // Agregar el nuevo lessor a la base de datos
            await _contextLessor.Lessors.AddAsync(lessor);

            // Guardar los cambios
            await _contextLessor.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lessor>> GetAllLessorsAsync()
        {
            return await _contextLessor.Lessors.ToListAsync();
        }

        public async Task<Lessor> GetLessorByIdAsync(int id)
        {
            return await _contextLessor.Lessors.FindAsync(id);
        }

        public async Task UpdateLessorAsync(Lessor lessor)
        {
            // Current lessor by Id
            var existingLessor = await GetLessorByIdAsync(lessor.IdLessor);

            if (existingLessor != null)
            {
                // Update current lessor
                existingLessor.IdLessor = lessor.IdLessor;
                existingLessor.StateDelete = lessor.StateDelete;

                // Marcar el lessor como modificado para que Entity Framework lo rastree
                //_contextLessor.Entry(existingLessor).State = EntityState.Modified;
                // Save lessor
                await _contextLessor.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Arrendador no encontrado");
            }
        }

        public async Task DeleteLessorAsync(int id)
        {
            // Current lessor by Id
            var currentLessor = await _contextLessor.Lessors.FindAsync(id);

            if (currentLessor != null)
            {
                // Update state delete
                currentLessor.StateDelete = true;

                await _contextLessor.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el arrendador");
            }
        }
    }
}

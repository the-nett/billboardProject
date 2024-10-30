using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface ILessorRepository
    {
        Task<ICollection<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync (int id);
        Task<Lessor> CreateLessorAsync (Lessor lessor);
        Task<Lessor> UpdateLessorAsync (Lessor lessor);
        Task DeleteLessorAsync(int id);
    }

    public class LessorRepository : ILessorRepository
    {
        private readonly BilllboardDBContext _contextLessor;
        public LessorRepository(BilllboardDBContext contextLessor)
        {
            _contextLessor = contextLessor;
        }

        public async Task<Lessor> CreateLessorAsync (Lessor lessor)
        {
            // Agregar el nuevo lessor a la base de datos
            await _contextLessor.Lessors.AddAsync(lessor);

            // Guardar los cambios
            await _contextLessor.SaveChangesAsync();
            return  lessor;
        }

        public async Task<ICollection<Lessor>> GetAllLessorsAsync()
        {
            return await _contextLessor.Lessors.ToListAsync();
        }

        public async Task<Lessor> GetLessorByIdAsync(int id)
        {
            return await _contextLessor.Lessors.FindAsync(id);
        }

        public async Task<Lessor> UpdateLessorAsync (Lessor lessor)
        {
            // Current lessor by Id
            var existingLessor = await GetLessorByIdAsync(lessor.IdLessor);

            if (existingLessor != null)
            {
                // Update current lessor
                existingLessor.IdUserType = lessor.IdUserType;
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
            return lessor;
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

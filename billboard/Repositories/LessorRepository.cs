using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface ILessorRepository
    {
        Task<IEnumerable<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync(int id);
        Task CreateLessorAsync(Lessor lessor);
        Task UpdateLessorAsync(Lessor lessor);
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

        public Task UpdateLessorAsync(Lessor lessor)
        {
            throw new NotImplementedException();
        }
    }
}

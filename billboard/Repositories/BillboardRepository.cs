using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;


namespace billboard.Repositories
{
    public interface IBillboardRepository
    {
        Task<IEnumerable<Billboard>> GetAllBillboardsAsync();
        Task<Billboard> GetBillboardByIdAsync(int id);
        Task CreateBillboardAsync(Billboard billboard);
        Task UpdateBillboardAsync(Billboard billboard);
        Task SoftDeleteBillboardAsync(int id);
    }

    public class BillboardRepository : IBillboardRepository
    {
        private readonly BilllboardDBContext _context;

        public BillboardRepository(BilllboardDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Billboard>> GetAllBillboardsAsync()
        {
            return await _context.Billboards
                .Include(b => b.Lessor)
                .Include(b => b.BillboardState)
                .Include(b => b.BillboardType)
                .ToListAsync();
        }

        public async Task<Billboard> GetBillboardByIdAsync(int id)
        {
            return await _context.Billboards
                .Include(b => b.Lessor)
                .Include(b => b.BillboardState)
                .Include(b => b.BillboardType)
                .FirstOrDefaultAsync(b => b.IdBillboard == id);
        }

        public async Task CreateBillboardAsync(Billboard billboard)
        {
            _context.Billboards.Add(billboard);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBillboardAsync(Billboard billboard)
        {
            _context.Billboards.Update(billboard);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteBillboardAsync(int id)
        {
            var billboard = await _context.Billboards.FindAsync(id);
            if (billboard != null)
            {
                // Marcar como eliminado de forma lógica
                billboard.State = false; // Asumiendo que el campo `State` indica si está activo o no
                await _context.SaveChangesAsync();
            }
        }
    }
}

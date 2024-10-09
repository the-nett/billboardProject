using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IBillboardRepository
    {
        Task<IEnumerable<Billboard>> GetAllBillboardsAsync();
        Task<Billboard> GetBillboardByIdAsync(int id);
        Task CreateBillboardAsync(Billboard billboard);
        Task UpdateBillboardAsync(Billboard billboard);
        Task DeleteBillboardAsync(int id);
    }

    public class BillboardRepository : IBillboardRepository
    {
        private readonly BilllboardDBContext _contextBillboard;
        public BillboardRepository(BilllboardDBContext contextBillboard)
        {
            _contextBillboard = contextBillboard;
        }

        public async Task CreateBillboardAsync(Billboard billboard)
        {
            // Agregar la nueva valla publicitaria a la base de datos
            await _contextBillboard.Billboards.AddAsync(billboard);

            // Guardar los cambios
            await _contextBillboard.SaveChangesAsync();
        }

        public async Task<IEnumerable<Billboard>> GetAllBillboardsAsync()
        {
            return await _contextBillboard.Billboards.ToListAsync();
        }

        public async Task<Billboard> GetBillboardByIdAsync(int id)
        {
            return await _contextBillboard.Billboards.FindAsync(id);
        }

        public async Task UpdateBillboardAsync(Billboard billboard)
        {
            // Valla actual por Id
            var existingBillboard = await GetBillboardByIdAsync(billboard.IdBillboard);

            if (existingBillboard != null)
            {
                // Actualizar la valla actual
                existingBillboard.IdBillboard = billboard.IdBillboard;
                existingBillboard.StateDelete = billboard.StateDelete;

                // Guardar la valla actualizada
                await _contextBillboard.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Valla publicitaria no encontrada");
            }
        }
        public async Task DeleteBillboardAsync(int id)
        {
            // Valla actual por Id
            var currentBillboard = await _contextBillboard.Billboards.FindAsync(id);

            if (currentBillboard != null)
            {
                // Actualizar estado de eliminación
                currentBillboard.StateDelete = true;

                await _contextBillboard.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar la valla publicitaria");
            }
        }
    }
}

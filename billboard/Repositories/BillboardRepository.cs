using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IBillboardRepository
    {
        Task<ICollection<Billboard>> GetAllBillboardsAsync();
        Task<Billboard> GetBillboardByIdAsync(int id);
        Task<Billboard> CreateBillboardAsync(Billboard billboard);
        Task<Billboard> UpdateBillboardAsync(Billboard billboard);
        Task DeleteBillboardAsync(int id);
    }

    public class BillboardRepository : IBillboardRepository
    {
        private readonly BilllboardDBContext _contextBillboard;
        public BillboardRepository(BilllboardDBContext contextBillboard)
        {
            _contextBillboard = contextBillboard;
        }

        public async Task<Billboard> CreateBillboardAsync(Billboard billboard)
        {
            billboard.StateDelete = false;
            // Agregar la nueva valla publicitaria a la base de datos
            await _contextBillboard.Billboards.AddAsync(billboard);

            // Guardar los cambios
            await _contextBillboard.SaveChangesAsync();
            return billboard;
        }

        public async Task<ICollection<Billboard>> GetAllBillboardsAsync()
        {
            return await _contextBillboard.Billboards.ToListAsync();
        }

        public async Task<Billboard> GetBillboardByIdAsync(int id)
        {
            return await _contextBillboard.Billboards.FindAsync(id);
        }

        public async Task<Billboard> UpdateBillboardAsync(Billboard billboard)
        {
            // Valla actual por Id
            var existingBillboard = await GetBillboardByIdAsync(billboard.IdBillboard);

            if (existingBillboard != null)
            {
                // Actualizar la valla actual
                existingBillboard.IdLessor = billboard.IdLessor;
                existingBillboard.ImageUrl = billboard.ImageUrl;
                existingBillboard.Fee = billboard.Fee;
                existingBillboard.IdBillboardState = billboard.IdBillboardState;
                existingBillboard.LatitudeAndLongitude = billboard.LatitudeAndLongitude;
                existingBillboard.IdBillboardType = billboard.IdBillboardType;
                existingBillboard.State = billboard.State;
                existingBillboard.Measures = billboard.Measures;
                existingBillboard.FloorDistance = billboard.FloorDistance;
                existingBillboard.Illumination = billboard.Illumination;
                existingBillboard.InstallationDate = billboard.InstallationDate;
                existingBillboard.SimultaneousAds = billboard.SimultaneousAds;
                existingBillboard.Observations = billboard.Observations;
                existingBillboard.StateDelete = billboard.StateDelete;

                // Guardar la valla actualizada
                await _contextBillboard.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Valla publicitaria no encontrada");
            }
            return billboard;
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

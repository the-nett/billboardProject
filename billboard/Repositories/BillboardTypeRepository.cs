using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IBillboardTypeRepository
    {
        Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync();
        Task<BillboardType> GetBillboardTypeByIdAsync(int id);
        Task CreateBillboardTypeAsync(BillboardType billboardType);
        Task UpdateBillboardTypeAsync(BillboardType billboardType);
        Task DeleteBillboardTypeAsync(int id);
    }

    public class BillboardTypeRepository : IBillboardTypeRepository
    {
        private readonly BilllboardDBContext _contextBillboardType;

        public BillboardTypeRepository(BilllboardDBContext contextBillboardType)
        {
            _contextBillboardType = contextBillboardType;
        }

        public async Task CreateBillboardTypeAsync(BillboardType billboardType)
        {
            // Agregar el nuevo billboardType a la base de datos
            await _contextBillboardType.BillboardTypes.AddAsync(billboardType);

            // Guardar los cambios
            await _contextBillboardType.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync()
        {
            return await _contextBillboardType.BillboardTypes.ToListAsync();
        }

        public async Task<BillboardType> GetBillboardTypeByIdAsync(int id)
        {
            return await _contextBillboardType.BillboardTypes.FindAsync(id);
        }

        public async Task UpdateBillboardTypeAsync(BillboardType billboardType)
        {
            // Current billboardType by Id
            var existingBillboardType = await GetBillboardTypeByIdAsync(billboardType.BillboardTypeId);

            if (existingBillboardType != null)
            {
                // Update current billboardType
                existingBillboardType.BillboardTypet = billboardType.BillboardTypet;
                existingBillboardType.StateDelete = billboardType.StateDelete;

                // Marcar el billboardType como modificado para que Entity Framework lo rastree
                //_contextBillboardType.Entry(existingBillboardType).State = EntityState.Modified;

                // Save billboardType
                await _contextBillboardType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Tipo de Valla Publicitaria no encontrado");
            }
        }

        public async Task DeleteBillboardTypeAsync(int id)
        {
            // Current billboardType by Id
            var currentBillboardType = await _contextBillboardType.BillboardTypes.FindAsync(id);

            if (currentBillboardType != null)
            {
                // Update state delete
                currentBillboardType.StateDelete = true;

                await _contextBillboardType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el Tipo de Valla Publicitaria");
            }
        }
    }
}

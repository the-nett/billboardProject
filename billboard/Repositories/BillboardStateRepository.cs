using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    public interface IBillboardStateRepository
    {
        Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync();
        Task<BillboardState> GetBillboardStateByIdAsync(int id);
        Task CreateBillboardStateAsync(BillboardState billboardState);
        Task UpdateBillboardStateAsync(BillboardState billboardState);
        Task DeleteBillboardStateAsync(int id);
    }

    public class BillboardStateRepository : IBillboardStateRepository
    {
        private readonly BilllboardDBContext _contextBillboardState;

        public BillboardStateRepository(BilllboardDBContext contextBillboardState)
        {
            _contextBillboardState = contextBillboardState;
        }

        public async Task CreateBillboardStateAsync(BillboardState billboardState)
        {
            // Agregar el nuevo estado a la base de datos
            await _contextBillboardState.BillboardStates.AddAsync(billboardState);

            // Guardar los cambios
            await _contextBillboardState.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync()
        {
            return await _contextBillboardState.BillboardStates.ToListAsync();
        }

        public async Task<BillboardState> GetBillboardStateByIdAsync(int id)
        {
            return await _contextBillboardState.BillboardStates.FindAsync(id);
        }

        public async Task UpdateBillboardStateAsync(BillboardState billboardState)
        {
            // Current billboardState by Id
            var existingBillboardState = await GetBillboardStateByIdAsync(billboardState.IdSate);

            if (existingBillboardState != null)
            {
                // Update current billboardState
                existingBillboardState.State = billboardState.State;
                existingBillboardState.StateDelete = billboardState.StateDelete;

                // Save changes
                await _contextBillboardState.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Estado de Valla Publicitaria no encontrado");
            }
        }

        public async Task DeleteBillboardStateAsync(int id)
        {
            // Current billboardState by Id
            var currentBillboardState = await _contextBillboardState.BillboardStates.FindAsync(id);

            if (currentBillboardState != null)
            {
                // Update state delete
                currentBillboardState.StateDelete = true;

                await _contextBillboardState.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el Estado de la Valla Publicitaria");
            }
        }
    }
}

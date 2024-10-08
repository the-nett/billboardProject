using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface IBillboardStateRepository
    {
        Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync();
        Task<BillboardState> GetBillboardStateByIdAsync(int id);
        Task CreateBillboardStateAsync(BillboardState billboardState);
        Task UpdateBillboardStateAsync(BillboardState billboardState);
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
            // Agregar el nuevo estado de valla a la base de datos
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
            var existingBillboardState = await GetBillboardStateByIdAsync(billboardState.IdSate);

            if (existingBillboardState != null)
            {
                existingBillboardState.BillboardStateName = billboardState.BillboardStateName;

                await _contextBillboardState.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Estado no encontrado");
            }
        }
    }
}

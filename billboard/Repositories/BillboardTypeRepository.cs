using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface IBillboardTypeRepository
    {
        Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync();
        Task<BillboardType> GetBillboardTypeByIdAsync(int id);
        Task CreateBillboardTypeAsync(BillboardType billboardType);
        Task UpdateBillboardTypeAsync(BillboardType billboardType);
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
            var existingBillboardType = await GetBillboardTypeByIdAsync(billboardType.BillboardTypeId);

            if (existingBillboardType != null)
            {
                existingBillboardType.BillboardTypeName = billboardType.BillboardTypeName;

                await _contextBillboardType.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Tipo de valla no encontrado");
            }
        }
    }
}

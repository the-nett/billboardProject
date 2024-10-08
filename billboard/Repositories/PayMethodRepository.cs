using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace billboard.Repositories
{
    public interface IPayMethodRepository
    {
        Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync();
        Task<PayMethods> GetPayMethodByIdAsync(int id);
        Task CreatePayMethodAsync(PayMethods paymethods);
        Task UpdatePayMethodAsync(PayMethods paymethods);
    }

    public class PayMethodRepository : IPayMethodRepository
    {
        private readonly BilllboardDBContext _contextPayMethod;
        public PayMethodRepository(BilllboardDBContext contextPayMethod)
        {
            _contextPayMethod = contextPayMethod;
        }

        public async Task CreatePayMethodAsync(PayMethods paymethods)
        {
            // Agregar el nuevo método de pago a la base de datos
            await _contextPayMethod.PayMethods.AddAsync(paymethods);

            // Guardar los cambios
            await _contextPayMethod.SaveChangesAsync();
        }

        public async Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync()
        {
            return await _contextPayMethod.PayMethods.ToListAsync();
        }

        public async Task<PayMethods> GetPayMethodByIdAsync(int id)
        {
            return await _contextPayMethod.PayMethods.FindAsync(id);
        }

        public async Task UpdatePayMethodAsync(PayMethods paymethods)
        {
            // Current document by Id
            var existingPayMethod = await GetPayMethodByIdAsync(paymethods.IdPayMethod);

            if (existingPayMethod != null)
            {
                // Update current pay method
                existingPayMethod.PayMethodName = paymethods.PayMethodName;

                // Marcar el documento como modificado para que Entity Framework lo rastree
                //_contextDocument.Entry(existingPayMethod).State = EntityState.Modified;
                // Save pay method
                await _contextPayMethod.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Método de pago no encontrado");
            }
        }

    }
}
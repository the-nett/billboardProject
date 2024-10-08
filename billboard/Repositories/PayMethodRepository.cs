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

        public Task UpdatePayMethodAsync(PayMethods paymethods)
        {
            throw new NotImplementedException();
        }
    }
}
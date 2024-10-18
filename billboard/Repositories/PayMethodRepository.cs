using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    public interface IPayMethodRepository
    {
        Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync();
        Task<PayMethods> GetPayMethodByIdAsync(int id);
        Task CreatePayMethodAsync(PayMethods paymethods);
        Task UpdatePayMethodAsync(PayMethods paymethods);
        Task DeletePayMethodAsync(int id);
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
            // Método de pago actual por Id
            var existingPayMethod = await GetPayMethodByIdAsync(paymethods.IdPayMethod);

            if (existingPayMethod != null)
            {
                // Actualizar el método de pago actual
                existingPayMethod.PayMethod = paymethods.PayMethod;
                existingPayMethod.StateDelete = paymethods.StateDelete;

                // Marcar el método de pago como modificado para que Entity Framework lo rastree
                //_contextPayMethod.Entry(existingPayMethod).State = EntityState.Modified;
                // Guardar el método de pago
                await _contextPayMethod.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Método de pago no encontrado");
            }
        }

        public async Task DeletePayMethodAsync(int id)
        {
            // Método de pago actual por Id
            var currentPayMethod = await _contextPayMethod.PayMethods.FindAsync(id);

            if (currentPayMethod != null)
            {
                // Actualizar estado de eliminación
                currentPayMethod.StateDelete = true;

                await _contextPayMethod.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el método de pago");
            }
        }
    }
}

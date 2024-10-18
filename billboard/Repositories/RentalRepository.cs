using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task CreateRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }

    public class RentalRepository : IRentalRepository
    {
        private readonly BilllboardDBContext _contextRental;
        public RentalRepository(BilllboardDBContext contextRental)
        {
            _contextRental = contextRental;
        }

        public async Task CreateRentalAsync(Rental rental)
        {
            // Agregar el nuevo rental a la base de datos
            await _contextRental.Rentals.AddAsync(rental);

            // Guardar los cambios
            await _contextRental.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _contextRental.Rentals.ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _contextRental.Rentals.FindAsync(id);
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            // Current rental by Id
            var existingRental = await GetRentalByIdAsync(rental.IdRental);

            if (existingRental != null)
            {
                // Update current rental
                existingRental.IdRental = rental.IdRental;
                existingRental.StateDelete = rental.StateDelete;

                // Marcar el rental como modificado para que Entity Framework lo rastree
                //_contextRental.Entry(existingRental).State = EntityState.Modified;
                // Save rental
                await _contextRental.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Alquiler no encontrado");
            }
        }
        public async Task DeleteRentalAsync(int id)
        {
            // Current rental by Id
            var currentRental = await _contextRental.Rentals.FindAsync(id);

            if (currentRental != null)
            {
                // Update state delete
                currentRental.StateDelete = true;

                await _contextRental.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el alquiler");
            }
        }
    }
}

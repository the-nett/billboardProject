using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IRentalRepository
    {
        Task<ICollection<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task<Rental> CreateRentalAsync(Rental rental);
        Task<Rental> UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }

    public class RentalRepository : IRentalRepository
    {
        private readonly BilllboardDBContext _contextRental;
        public RentalRepository(BilllboardDBContext contextRental)
        {
            _contextRental = contextRental;
        }

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            rental.StateDelete = false;
            // Agregar el nuevo rental a la base de datos
            await _contextRental.Rentals.AddAsync(rental);

            // Guardar los cambios
            await _contextRental.SaveChangesAsync();
            return rental;
        }

        public async Task<ICollection<Rental>> GetAllRentalsAsync()
        {
            return await _contextRental.Rentals.ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _contextRental.Rentals.FindAsync(id);
        }

        public async Task<Rental> UpdateRentalAsync(Rental rental)
        {
            // Current rental by Id
            var existingRental = await GetRentalByIdAsync(rental.IdRental);

            if (existingRental != null)
            {
                // Update current rental
                existingRental.IdBillboard = rental.IdBillboard;
                existingRental.IdLessor = rental.IdLessor;
                existingRental.IdTenant = rental.IdTenant;
                existingRental.RentalStartDate = rental.RentalStartDate;
                existingRental.RentalEndDate = rental.RentalEndDate;
                existingRental.IdPayMethods = rental.IdPayMethods;
                existingRental.AdContent = rental.AdContent;
                existingRental.ContractClauses = rental.ContractClauses;
                existingRental.Observations = rental.Observations;
                existingRental.StateDelete = rental.StateDelete;

                // Save rental
                await _contextRental.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Alquiler no encontrado");
            }
            return rental;
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

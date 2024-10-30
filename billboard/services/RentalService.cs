using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IRentalService
    {
        Task<ICollection<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task<Rental> CreateRentalAsync(Rental rental);
        Task<Rental> UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }

    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
           return await _rentalRepository.CreateRentalAsync(rental);
        }

        public Task<ICollection<Rental>> GetAllRentalsAsync()
        {
            return _rentalRepository.GetAllRentalsAsync();
        }

        public Task<Rental> GetRentalByIdAsync(int id)
        {
            return _rentalRepository.GetRentalByIdAsync(id);
        }

        public async Task<Rental> UpdateRentalAsync(Rental rental)
        {
            return await _rentalRepository.UpdateRentalAsync(rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _rentalRepository.DeleteRentalAsync(id);
        }
    }
}

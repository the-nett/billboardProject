using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IRentalService
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task CreateRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }

    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task CreateRentalAsync(Rental rental)
        {
            await _rentalRepository.CreateRentalAsync(rental);
        }

        public Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return _rentalRepository.GetAllRentalsAsync();
        }

        public Task<Rental> GetRentalByIdAsync(int id)
        {
            return _rentalRepository.GetRentalByIdAsync(id);
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            await _rentalRepository.UpdateRentalAsync(rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _rentalRepository.DeleteRentalAsync(id);
        }
    }
}

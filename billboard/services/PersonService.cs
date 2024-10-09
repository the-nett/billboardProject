using billboard.Model;
using billboard.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePersonAsync(Person person)
        {
            await _personRepository.CreatePersonAsync(person);
        }

        public Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return _personRepository.GetAllPeopleAsync();
        }

        public Task<Person> GetPersonByIdAsync(int id)
        {
            return _personRepository.GetPersonByIdAsync(id);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await _personRepository.UpdatePersonAsync(person);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personRepository.DeletePersonAsync(id);
        }
    }

}

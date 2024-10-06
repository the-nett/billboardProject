using billboard.Model;
using billboard.Repositories;

namespace billboard.services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
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

        public Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return _personRepository.GetAllPersonAsync();
        }

        public Task<Person> GetPersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}

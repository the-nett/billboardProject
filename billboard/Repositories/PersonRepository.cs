using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;

namespace billboard.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
       
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly BilllboardDBContext _contextPerson;
        public PersonRepository(BilllboardDBContext context)
        {
            _contextPerson = context;
        }
        public async Task CreatePersonAsync(Person person)
        {
            // Agregar el nuevo sujeto a la base de datos
            await _contextPerson.People.AddAsync(person);

            // Guardar los cambios
            await _contextPerson.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await _contextPerson.People.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _contextPerson.People.FindAsync(id);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            // Current document by Id
            var existingPerson = await GetPersonByIdAsync(person.IdPeople);

            if (existingPerson != null)
            {
                // Update current person
                existingPerson.PersonName = person.PersonName;

                // Marcar el documento como modificado para que Entity Framework lo rastree
                //_contextDocument.Entry(existingDocument).State = EntityState.Modified;
                // Save person
                await _contextPerson.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Persona no encontrada");
            }
        }
    }
}

using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly BilllboardDBContext _contextPerson;
        public PersonRepository(BilllboardDBContext contextPerson)
        {
            _contextPerson = contextPerson;
        }

        public async Task CreatePersonAsync(Person person)
        {
            // Agregar la nueva persona a la base de datos
            await _contextPerson.People.AddAsync(person);

            // Guardar los cambios
            await _contextPerson.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _contextPerson.People.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _contextPerson.People.FindAsync(id);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            // Current person by Id
            var existingPerson = await GetPersonByIdAsync(person.IdPeople);

            if (existingPerson != null)
            {
                //Update current person
                existingPerson.IdPeople = person.IdPeople;
                existingPerson.StateDelete = person.StateDelete;

                // Marcar la persona como modificada para que Entity Framework lo rastree
                //_contextPerson.Entry(existingPerson).State = EntityState.Modified;
                // Save person
                await _contextPerson.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Persona no encontrada");
            }
        }

        public async Task DeletePersonAsync(int id)
        {
            // Current person by Id
            var currentPerson = await _contextPerson.People.FindAsync(id);

            if (currentPerson != null)
            {
                //Update state delete
                currentPerson.StateDelete = true;

                await _contextPerson.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar la persona");
            }
        }
    }
}

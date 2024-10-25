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
        Task<ICollection<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<Person> CreatePersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly BilllboardDBContext _contextPerson;

        public PersonRepository(BilllboardDBContext contextPerson)
        {
            _contextPerson = contextPerson;
        }

        public async Task<ICollection<Person>> GetAllPeopleAsync()
        {
            // Retorna todas las personas de la base de datos
            return await _contextPerson.People.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            // Busca una persona por su ID
            return await _contextPerson.People.FindAsync(id);
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            person.IdUserType = 3;
            person.Date = DateTime.Now;
            // Añade una nueva persona a la base de datos
            await _contextPerson.People.AddAsync(person);
            await _contextPerson.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            // Busca la persona existente por su ID
            var existingPerson = await GetPersonByIdAsync(person.IdPeople);

            if (existingPerson != null)
            {
                // Actualiza las propiedades necesarias
                existingPerson.Name = person.Name;
                existingPerson.LastName = person.LastName;
                existingPerson.IdDocumentType = person.IdDocumentType;
                existingPerson.DocumentNumb = person.DocumentNumb;
                existingPerson.Occupation = person.Occupation;
                existingPerson.BirthDate = person.BirthDate;
                existingPerson.Email = person.Email;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.IdUserType = person.IdUserType;
                existingPerson.Date = DateTime.Now;
                existingPerson.StateDelete = person.StateDelete;

                // Guarda los cambios
                await _contextPerson.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Persona no encontrada");
            }

            return person;
        }

        public async Task DeletePersonAsync(int id)
        {
            // Busca la persona por su ID
            var currentPerson = await _contextPerson.People.FindAsync(id);

            if (currentPerson != null)
            {
                // Marca la persona como eliminada (StateDelete en lugar de eliminación física)
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

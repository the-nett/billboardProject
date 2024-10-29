using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    // Interface for company methods
    public interface ICompanyRepository
    {
        Task<ICollection<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
    }

    // Class for company operations
    public class CompanyRepository : ICompanyRepository
    {

        private readonly BilllboardDBContext _contextCompany;
        public CompanyRepository(BilllboardDBContext contextCompany)
        {
            _contextCompany = contextCompany;
        }

        public async Task<Company> CreateCompanyAsync (Company company)
        {
            company.Id_User_Type = 2;
            company.Company_Salt = GenerateRandomSalt(10); // Generar una cadena aleatoria de 10 caracteres
            company.Date = DateTime.Now;
            company.StateDelete = false;
            await _contextCompany.Companies.AddAsync(company);
            await _contextCompany.SaveChangesAsync();
            return company;
        }

        // Get all companies from database
        public async Task<ICollection<Company>> GetAllCompaniesAsync()
        {
            return await _contextCompany.Companies.ToListAsync();
        }

        // Get a company by its ID
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _contextCompany.Companies.FindAsync(id);
        }
        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            // Obtener la compañía actual por Id
            var existingCompany = await GetCompanyByIdAsync(company.IdCompany);

            if (existingCompany != null)
            {
                // Actualizar la compañía actual
                existingCompany.Company_Name = company.Company_Name;
                existingCompany.IdIndustry = company.IdIndustry;
                existingCompany.NIT = company.NIT;
                existingCompany.Owner_Name = company.Owner_Name;
                existingCompany.Company_Direction = company.Company_Direction;
                existingCompany.IdCity = company.IdCity;
                existingCompany.Phone_Number = company.Phone_Number;
                existingCompany.Corporate_Email = company.Corporate_Email;
                existingCompany.Password = company.Password;
                existingCompany.Date = DateTime.Now;
                existingCompany.StateDelete = company.StateDelete;

                // Guardar los cambios
                await _contextCompany.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Compañía no encontrada");
            }
            return company;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            // Obtener la compañía actual por Id
            var currentCompany = await _contextCompany.Companies.FindAsync(id);

            if (currentCompany != null)
            {
                // Actualizar estado de eliminación
                currentCompany.StateDelete = true;

                await _contextCompany.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar la compañía");
            }
        }

        public Task CreateCompany(string companyName, int industry, string nit, string ownerName, string companyDirection, string city, string phoneNumber, string corporateEmail, int responsible, string password, int userType)
        {
            throw new NotImplementedException();
        }
        // Método para generar una cadena aleatoria de salt
        private static string GenerateRandomSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

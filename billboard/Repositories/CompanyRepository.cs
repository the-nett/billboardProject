using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task CreateCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly BilllboardDBContext _contextCompany;
        public CompanyRepository(BilllboardDBContext contextCompany)
        {
            _contextCompany = contextCompany;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            // Agregar la nueva compañía a la base de datos
            await _contextCompany.Companies.AddAsync(company);

            // Guardar los cambios
            await _contextCompany.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _contextCompany.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _contextCompany.Companies.FindAsync(id);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            // Obtener la compañía actual por Id
            var existingCompany = await GetCompanyByIdAsync(company.IdCompany);

            if (existingCompany != null)
            {
                // Actualizar la compañía actual
                existingCompany.Company_Name = company.Company_Name;
                existingCompany.StateDelete = company.StateDelete;

                // Guardar los cambios
                await _contextCompany.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Compañía no encontrada");
            }
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
    }
}

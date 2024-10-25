using billboard.Model;
using billboard.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Services
{
    // Definimos una interfaz para el servicio de la compañía
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task CreateCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
    }

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task CreateCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompanyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}

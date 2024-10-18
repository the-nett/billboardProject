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

        public async Task CreateCompanyAsync(Company company)
        {
            await _companyRepository.CreateCompanyAsync(company);
        }

        public Task CreateCompany(string companyName, int industry, string nit, string ownerName, string companyDirection, int city, string phoneNumber, string corporateEmail, int responsible, string password, int userType)
        {       
            // Lógica para crear el objeto de compañía
            var company = new Company
            {   
                Company_Name = companyName,
                IdIndustry = industry,
                NIT = nit,
                Owner_Name = ownerName,
                Company_Direction = companyDirection,
                IdCity = city,
                Phone_Number = phoneNumber,
                Corporate_Email = corporateEmail,
                IdResponsible = responsible,
                Password = password,
                Id_User_Type = userType
            };  
            return _companyRepository.CreateCompany(company);
        }       

        // Método para obtener todas las compañías
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return _companyRepository.GetAllCompaniesAsync();
        }

        // Método para obtener una compañía por su ID
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return _companyRepository.GetCompanyByIdAsync(id);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            await _companyRepository.UpdateCompanyAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
        }
    }
}

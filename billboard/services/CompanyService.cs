using billboard.Model;
using billboard.Model.Dtos.Company;
using billboard.Repositories;

namespace billboard.Services
{
    // Definimos una interfaz para el servicio de la compañía
    public interface ICompanyService
    {
        Task<ICollection<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
        Task<AnswerLoginCompany> LoginCompany(LoginCompanyDto loginCompanyDto);
    }

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            return await _companyRepository.CreateCompanyAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
        }

        public Task<ICollection<Company>> GetAllCompaniesAsync()
        {
            return _companyRepository.GetAllCompaniesAsync();
        }

        public Task<Company> GetCompanyByIdAsync(int id)
        {
            return _companyRepository.GetCompanyByIdAsync(id);
        }

        public async Task<AnswerLoginCompany> LoginCompany(LoginCompanyDto loginCompanyDto)
        {
            return await _companyRepository.LoginCompany(loginCompanyDto);
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            return await _companyRepository.UpdateCompanyAsync(company);
        }
    }
}

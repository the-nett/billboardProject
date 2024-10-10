using billboard.Model;
using billboard.Model.Dtos;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<AnswerCompanyLoginDto> Login(LoginCompanyDto loginCompanyDto);
        Task<DataCompanyDto> Register(RegisterCompanyDto registerCompanyDto);
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _CompanyService;
        public CompanyService(ICompanyRepository documentRepository)
        {
            _CompanyService = documentRepository;
        }

        public Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyByIdAsync(int id)
        {
            return _CompanyService.GetCompanyByIdAsync(id);
        }

        public Task<AnswerCompanyLoginDto> Login(LoginCompanyDto loginCompanyDto)
        {
            throw new NotImplementedException();
        }

        public Task<DataCompanyDto> Register(RegisterCompanyDto registerCompanyDto)
        {
            throw new NotImplementedException();
        }
    }

}

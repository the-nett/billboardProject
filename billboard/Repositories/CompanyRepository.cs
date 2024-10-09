using billboard.Context;
using billboard.Model;
using billboard.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace billboard.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<AnswerCompanyLoginDto> Login(LoginCompanyDto loginCompanyDto);
        Task<Company> Register(RegisterCompanyDto registerCompanyDto);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly BilllboardDBContext _contextCompany;

        public CompanyRepository(BilllboardDBContext companyDocument)
        {
            _contextCompany = companyDocument;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _contextCompany.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _contextCompany.Companies.FindAsync(id);
        }

        public Task<AnswerCompanyLoginDto> Login(LoginCompanyDto loginCompanyDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> Register(RegisterCompanyDto registerCompanyDto)
        {
            var encryptedPassword = Obtainmd5(registerCompanyDto.Password);

            Company company = new Company()
            {
                Company_Name = registerCompanyDto.Company_Name,
                NIT = registerCompanyDto.NIT,
                Owner_Name = registerCompanyDto.Owner_Name,
                Company_Direction = registerCompanyDto.Company_Direction,
                Phone_Number = registerCompanyDto.Phone_Number,
                Corporate_Email = registerCompanyDto.Corporate_Email,
                Password = encryptedPassword,
                StateDelete = false
            };

            _contextCompany.Companies.Add(company);
            await _contextCompany.SaveChangesAsync();

            return company;
        }

        // Función corregida
        public static string Obtainmd5(string valor)
        {
            using (MD5 md5 = MD5.Create())  // Usar MD5.Create() en lugar de MD5CryptoServiceProvider
            {
                byte[] data = Encoding.UTF8.GetBytes(valor);
                byte[] hashData = md5.ComputeHash(data);

                StringBuilder resp = new StringBuilder();
                for (int i = 0; i < hashData.Length; i++)
                {
                    resp.Append(hashData[i].ToString("x2"));  // Convertir el byte en hexadecimal
                }

                return resp.ToString();
            }
        }
    }
}

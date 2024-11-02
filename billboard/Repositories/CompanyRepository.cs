using billboard.Context;
using billboard.Model;
using billboard.Model.Dtos.Company;
using billboard.Model.Dtos.NaturalPerson;
using billboard.Model.Dtos.UserNaturalPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        Task<AnswerLoginCompany> LoginCompany(LoginCompanyDto loginCompanyDto);
    }

    // Class for company operations
    public class CompanyRepository : ICompanyRepository
    {

        private readonly BilllboardDBContext _contextCompany;
        private string secretKey;
        public CompanyRepository(BilllboardDBContext contextCompany, IConfiguration config)
        {
            _contextCompany = contextCompany;
            secretKey = config.GetValue<string>("ApiSettings:Key");
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

        public async Task<AnswerLoginCompany> LoginCompany(LoginCompanyDto loginCompanyDto)
        {
            // var emailPerson = _contextPerson.People.FirstOrDefault(e => e.Email.ToLower() == logInNaturalPerson.Email.ToLower());
            // var passwordUser = _contextUser.Users.FirstOrDefault(p => p.PeoplePassword == logInNaturalPerson.PeoplePassword);

            var company = _contextCompany.Companies.FirstOrDefault(c => c.Corporate_Email.ToLower() == loginCompanyDto.Corporate_Email.ToLower() &&
                c.Password == loginCompanyDto.Password);

            //No hay coincidencia
            if (company == null)
            {
                return new AnswerLoginCompany()
                {
                    Token = "",
                    company = null
                };
            }

            // Si hay coincidencia
            var manageToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, company.Corporate_Email.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Crear una instancia de UserLoginDto y asignar los valores necesarios
            var answerCompanyLoginDto = new AnswerCompanyLoginDto
            {
                IdCompany = company.IdCompany, // Asumiendo que la clase Person tiene PeopleId
                Company_Name = company.Company_Name, // Asumiendo que la clase Person tiene Name
                Corporate_Email = company.Corporate_Email, // Correo electrónico del usuario
            };
            var token = manageToken.CreateToken(tokenDescriptor);
            // Crear y retornar el objeto AnswerLogInNaturalPerson
            var answer = new AnswerLoginCompany
            {
                Token = manageToken.WriteToken(token), // Asumiendo que ya tienes un token generado
                company = answerCompanyLoginDto // Asignar la instancia de UserLoginDto

            };

            return answer;

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

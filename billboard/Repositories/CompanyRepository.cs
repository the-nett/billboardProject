using billboard.Context;
using billboard.Model.Dtos;
using billboard.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace billboard.Repositories
{
    // Interface for company methods
    public interface ICompanyRepository
    {
        Task CreateCompany(Company company);
        Task<IEnumerable<Company>> GetAllCompaniesAsync(); // Get all companies
        Task<Company> GetCompanyByIdAsync(int id); // Get company by ID
        Task<AnswerCompanyLoginDto> Login(LoginCompanyDto loginCompanyDto); // Login method
        Task<Company> Register(RegisterCompanyDto registerCompanyDto); // Register method
        Task CreateCompany(string companyName, int industry, string nit, string ownerName, string companyDirection, string city, string phoneNumber, string corporateEmail, int responsible, string password, int userType);
    }

    // Class for company operations
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BilllboardDBContext _contextCompany; // Database context
        private string secretkey; // Secret key for tokens

        // Constructor to initialize database context and secret key
        public CompanyRepository(BilllboardDBContext companyDocument, IConfiguration config)
        {
            _contextCompany = companyDocument;
            secretkey = config.GetValue<string>("ApiSettings:Key");
        }

        // Get all companies from database
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _contextCompany.Companies.ToListAsync();
        }

        // Get a company by its ID
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _contextCompany.Companies.FindAsync(id);
        }

        // Login method for company
        public async Task<AnswerCompanyLoginDto> Login(LoginCompanyDto loginCompanyDto)
        {
            // Encrypt the password and check if company exists
            var encryptedPassword = Obtainmd5(loginCompanyDto.Password);
            var company = _contextCompany.Companies.FirstOrDefault(
                u => u.Corporate_Email.ToLower() == loginCompanyDto.Corporate_Email.ToLower()
                && u.Password == encryptedPassword
            );

            // If company not found, return empty token
            if (company == null)
            {
                return new AnswerCompanyLoginDto()
                {
                    Token = "",
                    Company = null
                };
            }

            // Create a token if login is successful
            var manageToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretkey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, company.Corporate_Email.ToString()) // Add claims
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Token expiration in 7 days
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manageToken.CreateToken(tokenDescriptor);
            AnswerCompanyLoginDto answerCompanyLoginDto = new AnswerCompanyLoginDto()
            { 
                Token = manageToken.WriteToken(token),
                Company = company
            };

            return answerCompanyLoginDto;
        }

        // Register a new company
        public async Task<Company> Register(RegisterCompanyDto registerCompanyDto)
        {
            // Encrypt password before saving
            var encryptedPassword = Obtainmd5(registerCompanyDto.Password);

            // Create new company object
            Company company = new Company()
            {
                Company_Name = registerCompanyDto.Company_Name,
                NIT = registerCompanyDto.NIT,
                Owner_Name = registerCompanyDto.Owner_Name,
                Company_Direction = registerCompanyDto.Company_Direction,
                Phone_Number = registerCompanyDto.Phone_Number,
                Corporate_Email = registerCompanyDto.Corporate_Email,
                Password = encryptedPassword,
                StateDelete = false // Set StateDelete to false
            };

            // Save company to database
            _contextCompany.Companies.Add(company);
            await _contextCompany.SaveChangesAsync();

            return company;
        }

        // Method to encrypt password using MD5
        public static string Obtainmd5(string valor)
        {
            using (MD5 md5 = MD5.Create())  // Use MD5.Create to create MD5 instance
            {
                byte[] data = Encoding.UTF8.GetBytes(valor); // Convert string to bytes
                byte[] hashData = md5.ComputeHash(data); // Compute the MD5 hash

                StringBuilder resp = new StringBuilder();
                for (int i = 0; i < hashData.Length; i++)
                {
                    resp.Append(hashData[i].ToString("x2")); // Convert bytes to hexadecimal
                }

                return resp.ToString(); // Return the encrypted string
            }
        }

        public Task CreateCompany(string companyName, int industry, string nit, string ownerName, string companyDirection, string city, string phoneNumber, string corporateEmail, int responsible, string password, int userType)
        {
            throw new NotImplementedException();
        }
    }
}

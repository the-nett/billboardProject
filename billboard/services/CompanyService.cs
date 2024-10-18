using billboard.Model;
using billboard.Model.Dtos;
using billboard.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Services
{
    // Definimos una interfaz para el servicio de la compañía
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(); // Obtener todas las compañías
        Task<Company> GetCompanyByIdAsync(int id); // Obtener una compañía por ID
        Task<AnswerCompanyLoginDto> LoginCompanyAsync(LoginCompanyDto loginCompanyDto); // Iniciar sesión
        Task<Company> RegisterCompanyAsync(RegisterCompanyDto registerCompanyDto); // Registrar nueva compañía
        Task CreateCompany(string companyName, int industry, string nit, string ownerName, string companyDirection, string city, string phoneNumber, string corporateEmail, int responsible, string password, int userType);
    }

    // Implementamos la clase del servicio
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        // Constructor para inyectar el repositorio de compañías
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
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
            return await _companyRepository.GetAllCompaniesAsync();
        }

        // Método para obtener una compañía por su ID
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetCompanyByIdAsync(id);
        }

        // Método para iniciar sesión de la compañía
        public async Task<AnswerCompanyLoginDto> LoginCompanyAsync(LoginCompanyDto loginCompanyDto)
        {
            // Aquí puedes agregar cualquier lógica adicional de negocio o validación
            if (string.IsNullOrEmpty(loginCompanyDto.Corporate_Email) || string.IsNullOrEmpty(loginCompanyDto.Password))
            {
                // Retornar null o algún mensaje de error si no se ingresaron los datos correctos
                return new AnswerCompanyLoginDto
                {
                    Token = "",
                    Company = null
                };
            }

            // Llamar al método de login del repositorio
            return await _companyRepository.Login(loginCompanyDto);
        }

        // Método para registrar una nueva compañía
        public async Task<Company> RegisterCompanyAsync(RegisterCompanyDto registerCompanyDto)
        {
            // Lógica adicional antes de registrar, como validar si los campos son correctos
            if (string.IsNullOrEmpty(registerCompanyDto.Company_Name) || string.IsNullOrEmpty(registerCompanyDto.Password))
            {
                return null;
            }

            // Registrar la compañía usando el repositorio
            return await _companyRepository.Register(registerCompanyDto);
        }
    }
}

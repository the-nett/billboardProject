using billboard.Context;
using billboard.Model;
using billboard.Model.Dtos.NaturalPerson;
using billboard.Model.Dtos.UserNaturalPerson;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace billboard.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<AnswerLogInNaturalPerson> Login (LogInNaturalPerson logInNaturalPerson);
    }

    public class UserRepository : IUserRepository
    {
        private readonly BilllboardDBContext _contextUser;
        private readonly BilllboardDBContext _contextPerson;
        private string secretKey;
        public static int idPeopleLogIn;

        public UserRepository(BilllboardDBContext contextUser, BilllboardDBContext contextPerson, IConfiguration config)
        {
            _contextUser = contextUser;
            _contextPerson = contextPerson;
            secretKey = config.GetValue<string>("ApiSettings:Key");
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.IdUserType = 1;
            user.Date = DateTime.Now;
            user.PeopleSalt = GenerateRandomSalt(10); // Generar una cadena aleatoria de 10 caracteres

            // Agregar el nuevo usuario a la base de datos
            await _contextUser.Users.AddAsync(user);

            // Guardar los cambios
            await _contextUser.SaveChangesAsync();
            return user;
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _contextUser.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _contextUser.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            // Busca el usuario existente por su ID
            var existingUser = await GetUserByIdAsync(user.IdUser);

            if (existingUser != null)
            {
                // Actualiza las propiedades necesarias
                existingUser.PeoplePassword = user.PeoplePassword;
                existingUser.IdUserType = user.IdUserType;
                existingUser.Date = DateTime.Now;
                existingUser.StateDelete = user.StateDelete;

                // Guarda los cambios
                await _contextUser.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }

            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            // Buscar usuario por su ID
            var currentUser = await _contextUser.Users.FindAsync(id);

            if (currentUser != null)
            {
                // Marcar el estado de eliminación
                currentUser.StateDelete = true;

                await _contextUser.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se pudo eliminar el usuario");
            }
        }

        // Método para generar una cadena aleatoria de salt
        private static string GenerateRandomSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<AnswerLogInNaturalPerson> Login(LogInNaturalPerson logInNaturalPerson)
        {
            // var emailPerson = _contextPerson.People.FirstOrDefault(e => e.Email.ToLower() == logInNaturalPerson.Email.ToLower());
            // var passwordUser = _contextUser.Users.FirstOrDefault(p => p.PeoplePassword == logInNaturalPerson.PeoplePassword);

            var user = _contextUser.Users.Include(u => u.Person).FirstOrDefault(u => u.Person.Email.ToLower() == logInNaturalPerson.Email.ToLower() &&
                u.PeoplePassword == logInNaturalPerson.PeoplePassword);

            //No hay coincidencia
            if (user == null)
            {
                return new AnswerLogInNaturalPerson()
                {
                    Token = "",
                    Usser = null
                }; 
            }

            // Si hay coincidencia
            var manageToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Person.Email.ToString()),
                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Crear una instancia de UserLoginDto y asignar los valores necesarios
            var userLoginDto = new UserLoginDto
            {
                IdPeople = user.Person.IdPeople, // Asumiendo que la clase Person tiene PeopleId
                Name = user.Person.Name, // Asumiendo que la clase Person tiene Name
                Email = user.Person.Email, // Correo electrónico del usuario
                IdUser = user.IdUser, // Asumiendo que el objeto User tiene Id
                IdUserType = user.IdUserType // Asumiendo que el objeto User tiene IdUserType
            };
            var token = manageToken.CreateToken(tokenDescriptor);
            // Crear y retornar el objeto AnswerLogInNaturalPerson
            var answer = new AnswerLogInNaturalPerson
            {
                Token = manageToken.WriteToken(token), // Asumiendo que ya tienes un token generado
                Usser = userLoginDto // Asignar la instancia de UserLoginDto
                
            };
            idPeopleLogIn = user.Person.IdPeople;

            return answer;

        }

    }
}

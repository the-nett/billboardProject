using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.NaturalPerson;
using billboard.Model.Dtos.User;
using billboard.services;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var listUsers = await userService.GetAllUsersAsync();
            var listaUsersDto = new List<UserDto>();

            foreach (var user in listUsers)
            {
                listaUsersDto.Add(mapper.Map<UserDto>(user));
            }

            return Ok(listaUsersDto);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var userdto = mapper.Map<UserDto>(user);
            return Ok(userdto);
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateUserAsync ([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(createUserDto);

            var createUser = await userService.CreateUserAsync(user);
            return Ok();

        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.IdUser)
                return BadRequest();

            var user = mapper.Map<User>(updateUserDto);

            var updatePermission = await userService.UpdateUserAsync(user);

            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Current user by Id
            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await userService.DeleteUserAsync(id);

            return NoContent();
        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LogInNaturalPerson logInNaturalPerson)
        {
            
            var responseLogin = await userService.Login(logInNaturalPerson);

            if (responseLogin == null || responseLogin.Usser == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                return BadRequest("Invalid login credentials.");
            }

            return Ok(new
            {
                User = responseLogin.Usser,
                Token = responseLogin.Token
            });
        }


    }
}

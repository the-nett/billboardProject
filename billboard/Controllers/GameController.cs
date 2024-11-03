using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Company;
using billboard.Model.Dtos.Game;
using billboard.services;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;
        private readonly IMapper mapper;
        public GameController(IGameService _gameService, IMapper _mapper)
        {
            gameService = _gameService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllGames")]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var listGames = await gameService.GetAllGameAsync();
            var listGamesDto = new List<ShowGameDto>();
            foreach (var game in listGames)
            {
                listGamesDto.Add(mapper.Map<ShowGameDto>(game));
            }

            return Ok(listGamesDto);
        }
        [HttpGet("{id}", Name = "GetGameById")]
        public async Task<IActionResult> GetGameByIdAsync(int id)
        {
            var game = await gameService.GetGameByIdAsync(id);
            if (game == null)
                return NotFound();

            var gameToDto = mapper.Map<ShowGameDto>(game);
            return Ok(gameToDto);
        }

        [HttpPost(Name = "CreateGame")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateGameAsync([FromBody] ShowGameDto showGameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapea de ShowGameDto a la entidad Game
            var game = mapper.Map<Game>(showGameDto);

            // Guarda el juego creado
            var createdGame = await gameService.CreateGameAsync(game);

            // Mapea el objeto creado a GameDto para incluir IdGame en la respuesta
            var gameDto = mapper.Map<GameDto>(createdGame);

            // Retorna el estado 201 Created con GameDto, que incluye el IdGame generado
            return CreatedAtRoute("GetGameById", new { id = gameDto.IdGame }, gameDto);
        }
        [HttpPut("{id}", Name = "UpdateGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GameDto gameDto)
        {
            if (id != gameDto.IdGame)
                return BadRequest();

            // Mapea GameDto a la entidad Game
            var game = mapper.Map<Game>(gameDto);

            // Actualiza el juego en el servicio
            var updatedGame = await gameService.UpdateGameAsync(game);
            if (updatedGame == null)
            {
                return NotFound("No se encontró la partida especificada para actualizar.");
            }

            // Retorna el objeto actualizado directamente
            return Ok(updatedGame);
        }
    }
    
}

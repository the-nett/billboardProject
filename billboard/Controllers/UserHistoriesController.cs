using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHistoriesController : ControllerBase
    {
        private readonly IUserHistoriesService userHistoriesService;
        public UserHistoriesController(IUserHistoriesService _userHistoriesService)
        {
            userHistoriesService = _userHistoriesService;
        }

        [HttpGet(Name = "GetAllUserHistories")]
        public Task<IEnumerable<UserHistory>> GetAlUserHistoriesAsync()
        {
            return userHistoriesService.GetAlUserHistoriesAsync();
        }
    }
}

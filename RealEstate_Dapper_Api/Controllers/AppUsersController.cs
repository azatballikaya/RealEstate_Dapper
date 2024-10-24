using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById(int id)
        {
            return Ok(await _appUserRepository.GetAppUserByIdAsync(id));
        }
    }
}

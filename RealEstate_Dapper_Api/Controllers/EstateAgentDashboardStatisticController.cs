using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        [HttpGet("AllProductCount")]
        public async Task<IActionResult> AllProductCount()
        {
            return Ok(await _statisticRepository.AllProductCountAsync());
        }
        [HttpGet("ProductCountByEmployeeId/{id}")]
        public async Task<IActionResult> ProductCountByEmployeeId(int id)
        {
            return Ok(await _statisticRepository.ProductCountByEmployeeIdAsync(id));

        }
        [HttpGet("ProductCountByStatusFalse/{id}")]
        public async Task<IActionResult> ProductCountByStatusFalse(int id)
        {
            return Ok(await _statisticRepository.ProductCountByStatusFalseAsync(id));

        }
        [HttpGet("ProductCountByStatusTrue/{id}")]
        public async Task<IActionResult> ProductCountByStatusTrue(int id)
        {
            return Ok(await _statisticRepository.ProductCountByStatusTrueAsync(id));

        }

    }
}

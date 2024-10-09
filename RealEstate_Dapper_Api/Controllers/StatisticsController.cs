using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            return Ok(await _statisticRepository.ActiveCategoryCountAsync());
        }
        [HttpGet("ActiveEmployeeCount")]
        public async Task<IActionResult> ActiveEmployeeCount()
        {
            return Ok(await _statisticRepository.ActiveEmployeeCountAsync());
        }
        [HttpGet("ApartmentCount")]
        public async Task<IActionResult> ApartmentCount()
        {
            return Ok(await _statisticRepository.ApartmentCountAsync());
        }
        [HttpGet("AverageProductPriceBySale")]
        public async Task<IActionResult> AverageProductPriceBySale()
        {
            return Ok(await _statisticRepository.AverageProductPriceBySaleAsync());
        }
        [HttpGet("AverageProductByRent")]
        public async Task<IActionResult> AverageProductByRent()
        {
            return Ok(await _statisticRepository.AverageProductPriceByRentAsync());
        }
        [HttpGet("AverageRoomCount")]
        public async Task<IActionResult> AverageRoomCount()
        {
            return Ok(await _statisticRepository.AverageRoomCountAsync());
        }
        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            return Ok(await _statisticRepository.CategoryCountAsync());
        }
        [HttpGet("CategoryNameByMaxProductCountAsync")]
        public async Task<IActionResult> CategoryNameByMaxProductCountAsync()
        {
            return Ok(await _statisticRepository.CategoryNameByMaxProductCountAsync());
        }
        [HttpGet("CityNameByMaxProductCount")]

        public async Task<IActionResult> CityNameByMaxProductCount()
        {
            return Ok(await _statisticRepository.CityNameByMaxProductCountAsync());
        }
        [HttpGet("DifferentCityCount")]
        public async Task<IActionResult> DifferentCityCount()
        {
            return Ok(await _statisticRepository.DifferentCityCountAsync());
        }
        [HttpGet("EmployeeNameByMaxProductCount")]
        public async Task<IActionResult> EmployeeNameByMaxProductCount()
        {
            return Ok(await _statisticRepository.EmployeeNameByMaxProductCountAsync());
        }
        [HttpGet("LastProductPrice")]
        public async Task<IActionResult> LastProductPrice()
        {
            return Ok(await _statisticRepository.LastProductPriceAsync());
        }
        [HttpGet("NewestBuildingYear")]
        public async Task<IActionResult> NewestBuildingYear()
        {
            return Ok(await _statisticRepository.NewestBuildingYearAsync());
        }
        [HttpGet("OldestBuildingYear")]
        public async Task<IActionResult> OldestBuildingYear()
        {
            return Ok(await _statisticRepository.OldestBuildingYearAsync());
        }
        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            return Ok(await _statisticRepository.PassiveCategoryCountAsync());
        }
        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            return Ok(await _statisticRepository.ProductCountAsync());
        }
    }
}

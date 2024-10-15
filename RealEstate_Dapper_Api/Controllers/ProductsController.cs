using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values=await _productRepository.GetAllProductsAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductsWithCategoriesAsync();
            return Ok(values);
        }
        [HttpPut("ChangeDealOfTheDayStatusToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToFalseAsync(id);
            return Ok();
        }
        [HttpPut("ChangeDealOfTheDayStatusToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToTrueAsync(id);
            return Ok();
        }
        [HttpGet("Last5ProductByRentList")]
        public async Task<IActionResult> Last5Product()
        {
            var values=await _productRepository.GetLast5ProductsByRentAsync();
         
            return Ok(values);
        }
    }
}

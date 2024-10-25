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
        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5Product()
        {
            var values=await _productRepository.GetLast5ProductsAsync();
         
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeIdByTrue/{id}")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdByTrue(int id)
        {
            var values=await _productRepository.GetProductAdvertListByEmployeeIdByTrueAsync(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeIdByFalse/{id}")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeIdByFalseAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProductAsync(createProductDto);
            return Ok("İlan Başarıyla Eklendi...");
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var value=await _productRepository.GetProductByIdAsync(id);
            return Ok(value);
        }
        [HttpGet("ProductListBySearch")]
        public async Task<IActionResult> GetProductListBySearch(string searchKeyValue, int categoryId, string city)
        {
            var values = await _productRepository.GetProductListWithSearchAsync(searchKeyValue, categoryId, city);
            return Ok(values);
        }
    }
}

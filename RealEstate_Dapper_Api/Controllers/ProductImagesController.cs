using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesController(IProductImageRepository productImageRepository)
        {
            this._productImageRepository = productImageRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImages(int id)
        {
            var values=await _productImageRepository.GetProductImagesByProductIdAsync(id);
            return Ok(values);
        }
    }
}

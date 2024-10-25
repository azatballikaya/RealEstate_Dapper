using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }
        [HttpGet("PropertyAmenitiesStatusPropertyId/{id}")]
        public async Task<IActionResult> GetPropertyAmenitiesStatusPropertyId(int id)
        {
            var values=await _propertyAmenityRepository.GetPropertyAmenityStatusByPropertyIdAsync(id);
            return Ok(values);
        }
    }
}

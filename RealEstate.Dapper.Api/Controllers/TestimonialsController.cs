using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialReposittory _testimonialRepository;

        public TestimonialsController(ITestimonialReposittory testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ListTestimonials()
        {
            var values=await _testimonialRepository.GetAllTestimonialsAsync();
            return Ok(values);
        }
    }
}

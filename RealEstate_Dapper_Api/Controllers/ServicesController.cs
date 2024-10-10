using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var values=await _serviceRepository.GetAllServicesAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateServiceAsync(createServiceDto);
            return Ok("Hizmet Kısmı başarılı bir şekilde eklendi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateServiceAsync(updateServiceDto);
            return Ok("Hizmet Kısmı başarılı bir şekilde güncellendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value=await _serviceRepository.GetServiceByIdAsync(id);
            return Ok(value);
        }
    }
}

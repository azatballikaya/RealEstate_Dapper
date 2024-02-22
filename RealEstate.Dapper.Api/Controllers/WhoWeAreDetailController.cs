using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
        {
            _whoWeAreDetailRepository = whoWeAreDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            List<ResultWhoWeAreDetailDto> values = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreDetailRepository.GetWhoWeAreDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            await _whoWeAreDetailRepository.CreateWhoWeAreDetailAsync(createWhoWeAreDetailDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreDetailRepository.DeleteWhoWeAreDetailAsync(id);
            return Ok("Kategori Başarılı Bir Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _whoWeAreDetailRepository.UpdateWhoWeAreDetailAsync(updateWhoWeAreDetailDto);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
    }
}

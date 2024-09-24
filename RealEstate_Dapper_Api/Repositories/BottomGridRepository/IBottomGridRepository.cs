using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridsAsync();
        Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        Task DeleteBottomGridAsync(int id);
        Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
        Task<GetBottomGridByIdDto> GetBottomGridByIdAsync(int id);
    }
}

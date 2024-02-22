using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        Task CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        Task DeleteWhoWeAreDetailAsync(int id);
        Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id);
    }
}

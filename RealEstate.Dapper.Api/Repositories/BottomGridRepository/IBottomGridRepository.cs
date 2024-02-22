using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridsAsync();
        Task<ResultBottomGridDto> GetByIdBottomGridAsync();
        Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
        Task DeleteBottomGridAsync(int id); 
    }
}

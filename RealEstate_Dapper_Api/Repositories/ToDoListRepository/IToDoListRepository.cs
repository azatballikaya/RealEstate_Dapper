using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task CreateToDoListAsync(CreateToDoListDto createToDoListDto);
        Task DeleteToDoListAsync(int id);
        Task UpdateToDoListAsync(UpdateToDoListDto updateToDoListDto);
        Task<GetByIdToDoListDto> GetToDoListByIdAsync(int id);
    }
}

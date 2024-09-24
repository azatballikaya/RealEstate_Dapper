using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task DeleteServiceAsync(int id);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task<GetByIdServiceDto> GetServiceByIdAsync(int id);
    }
}

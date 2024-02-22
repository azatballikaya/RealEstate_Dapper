using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            throw new Exception();
        }

        public Task DeleteServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            string query = "Select * From Services";
            using (var connection=_context.CreateConnection())
            {
               var value= await connection.QueryAsync<ResultServiceDto>(query);
                return value.ToList();
            }
        }

        public Task<GetByIdServiceDto> GetServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}

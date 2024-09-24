using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "Insert INTO Services (ServiceName,ServiceStatus) VALUES (@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDto.ServiceName);
            parameters.Add("@serviceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
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
                var values=await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdServiceDto> GetServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}

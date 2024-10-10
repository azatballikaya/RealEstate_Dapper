using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "Insert INTO PopularLocation (CityName,ImageUrl) Values (@cityName,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName",createPopularLocationDto.CityName);
            parameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync(query,parameters);
               
                
               
            }
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            string query = "Delete FROM PopularLocation WHERE PopularLocationID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);



            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocationByIdAsync(int id)
        {
            string query = "Select * From PopularLocation WHERE PopularLocationID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation SET CityName=@cityName,ImageUrl=@imageUrl WHERE PopularLocationID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@id", updatePopularLocationDto.PopularLocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);



            }
        }
    }
}

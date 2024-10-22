using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ChartDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChartAsync()
        {

            string query = "Select Top(5) City,Count(*) as 'CityCount' From Product Group By City Order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();

            }
        }
    }
}

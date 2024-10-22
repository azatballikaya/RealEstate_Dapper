
using Dapper;
using RealEstate_Dapper_Api.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AllProductCountAsync()
        {
            string query = "Select Count(*) From Product";
            using (var connection=_context.CreateConnection())
            {
                var value=await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public async Task<int> ProductCountByEmployeeIdAsync(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query,parameters);
                return value;
            }
        }

        public async Task<int> ProductCountByStatusFalseAsync(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID=@employeeID and ProductStatus=0 ";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
                return value;
            }
        }

        public async Task<int> ProductCountByStatusTrueAsync(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID=@employeeID and ProductStatus=1 ";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
                return value;
            }
        }
    }
}

using Dapper;
using RealEstate_Dapper_Api.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> ActiveCategoryCountAsync()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<int> ActiveEmployeeCountAsync()
        {
            string query = "Select Count(*) From Employee Where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<int> ApartmentCountAsync()
        {
            string query = "Select Count(*) From Product Where Title like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<decimal> AverageProductPriceByRentAsync()
        {
            string query = "Select Avg(Price) From Product Where Type='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return values;
            }
        }

        public async Task<decimal> AverageProductPriceBySaleAsync()
        {
            string query = "Select Avg(Price) From Product Where Type='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return values;
            }
        }

        public async Task<decimal> AverageRoomCountAsync()
        {
            string query = "Select Avg(RoomCount) From ProductDetails ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return values;
            }
        }

        public async Task<int> CategoryCountAsync()
        {
            string query = "Select Count(*) From Category ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<string> CategoryNameByMaxProductCountAsync()
        {
            string query = "Select top(1) CategoryName From Product inner join Category on Product.ProductCategory=Category.CategoryID group by CategoryName order by Count(*) desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);
                return values;
            }
        }

        public Task<string> CityNameByMaxProductCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DifferentCityCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> EmployeeNameByMaxProductCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> LastProductPriceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> NewestBuildingYearAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> OldestBuildingYearAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> PassiveCategoryCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> ProductCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}

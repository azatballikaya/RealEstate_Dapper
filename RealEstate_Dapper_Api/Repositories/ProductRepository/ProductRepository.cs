using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoriesAsync()
        {
            string query = "Select * From Product inner join Category ON Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductByRentWithCategoryDto>> GetLast5ProductsByRentAsync()
        {
            string query = "Select Top(5) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Order by ProductId Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductByRentWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeIdDto>> GetProductAdvertListByEmployeeIdAsync(int id)
        {
            string query = "Select Top(5) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeIdDto>(query,parameters);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalseAsync(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 Where ProductId=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);   
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrueAsync(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 Where ProductId=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

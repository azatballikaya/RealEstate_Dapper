using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

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
            using (var connection=_context.CreateConnection())
            {
                var value=await connection.QueryAsync<ResultProductDto>(query);
                return value.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync()
        {
            string query = "Select * From Product INNER JOIN Category On Product.ProductCategory=Category.CategoryID";
            using (var connection=_context.CreateConnection())
            {
                var value=await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return value.ToList();
            }
        }
    }
}

using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;

        public Last5ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductsAsync(int id)
        {
            string query = "Select Top(5) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID Order by ProductId Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}

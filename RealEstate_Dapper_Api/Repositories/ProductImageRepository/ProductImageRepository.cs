using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductImageDto>> GetProductImagesByProductIdAsync(int id)
        {
            string query = "Select * From ProductImage WHERE ProductID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultProductImageDto>(query,parameters);
                return values.ToList();
            }
            
        }
    }
}

using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductsAsync()
        {
            string query = "Select Top(5) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Order by ProductId Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeIdDto>> GetProductAdvertListByEmployeeIdByTrueAsync(int id)
        {
            string query = "Select Top(5) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeIdDto>(query, parameters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeIdDto>> GetProductAdvertListByEmployeeIdByFalseAsync(int id)
        {
            string query = "Select Top(5) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID  and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeIdDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalseAsync(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 Where ProductId=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
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

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "Insert Into Product (Title,Price,CoverImage,City,District,Address,Description,Type,ProductCategory,EmployeeID,DealOfTheDay,AdvertiesmentDate,ProductStatus) VALUES (@Title,@Price,@CoverImage,@City,@District,@Address,@Description,@Type,@ProductCategory,@EmployeeID,@DealOfTheDay,@AdvertiesmentDate,@ProductStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeID", createProductDto.EmployeeID);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertiesmentDate", createProductDto.AdvertiesmentDate);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(int id)
        {
            string query = "Select * From Product inner join Category on Product.ProductCategory=Category.CategoryID Where ProductId=@id ";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetProductByIdDto>(query, parameters);
                return values;
            }
        }

        public async Task<GetProductDetailByProductIdDto> GetProductDetailByProductIdAsync(int id)
        {
            string query = "Select * From ProductDetails Where ProductDetailID=@id ";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetProductDetailByProductIdDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultProductWithSearchDto>> GetProductListWithSearchAsync(string searchKeyValue, int categoryId, string city)
        {
            string query = "Select * From Product Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryId And City=@city ";
                  var parameters = new DynamicParameters();
            //parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryId", categoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select * From Product inner join Category ON Product.ProductCategory=Category.CategoryID Where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductsAsync()
        {
            string query = "Select Top(3) * From Product inner join Category on Product.ProductCategory=Category.CategoryID Order by ProductId Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}

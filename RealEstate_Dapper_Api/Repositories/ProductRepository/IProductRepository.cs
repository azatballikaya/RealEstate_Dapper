using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoriesAsync();
        Task ProductDealOfTheDayStatusChangeToTrueAsync(int id);
        Task ProductDealOfTheDayStatusChangeToFalseAsync(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductsAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeIdDto>> GetProductAdvertListByEmployeeIdByTrueAsync(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeIdDto>> GetProductAdvertListByEmployeeIdByFalseAsync(int id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<GetProductByIdDto> GetProductByIdAsync(int id);
        Task<GetProductDetailByProductIdDto> GetProductDetailByProductIdAsync(int id);
        Task<List<ResultProductWithSearchDto>> GetProductListWithSearchAsync(string searchKeyValue,int categoryId,string city);
    }
}

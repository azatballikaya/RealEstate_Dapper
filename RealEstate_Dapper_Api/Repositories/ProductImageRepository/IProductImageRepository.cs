using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepository
{
    public interface IProductImageRepository
    {
        Task<List<ResultProductImageDto>> GetProductImagesByProductIdAsync(int id);
    }
}

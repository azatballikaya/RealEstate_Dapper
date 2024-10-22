using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository
{
    public interface ILast5ProductRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductsAsync(int id);
    }
}

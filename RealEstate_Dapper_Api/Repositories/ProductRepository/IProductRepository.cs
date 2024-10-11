﻿using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoriesAsync();
        Task ProductDealOfTheDayStatusChangeToTrueAsync(int id);
        Task ProductDealOfTheDayStatusChangeToFalseAsync(int id);
        
    }
}

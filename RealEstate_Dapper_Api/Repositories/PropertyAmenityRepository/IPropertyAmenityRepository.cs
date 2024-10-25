﻿using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityStatusDto>> GetPropertyAmenityStatusByPropertyIdAsync(int propertyId);
    }
}
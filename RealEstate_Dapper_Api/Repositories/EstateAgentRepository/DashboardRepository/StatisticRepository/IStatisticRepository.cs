﻿namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public interface IStatisticRepository
    {
     

      
        Task<int> ProductCountByEmployeeIdAsync(int id);
        Task<int> ProductCountByStatusTrueAsync(int id);
        Task<int> ProductCountByStatusFalseAsync(int id);
        Task<int> AllProductCountAsync();
    
    }
}

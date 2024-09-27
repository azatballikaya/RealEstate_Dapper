using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task<GetEmployeeByIdDto> GetEmployeeByIdAsync(int id);
    }
}

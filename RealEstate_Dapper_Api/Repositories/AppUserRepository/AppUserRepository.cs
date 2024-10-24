using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResultAppUserDto> GetAppUserByIdAsync(int id)
        {
            string query = "Select * From AppUser Where UserID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection=_context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultAppUserDto>(query, parameters);
                return value;
            }
        }
    }
}

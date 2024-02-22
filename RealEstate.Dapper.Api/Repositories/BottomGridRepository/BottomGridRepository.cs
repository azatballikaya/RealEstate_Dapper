using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridsAsync()
        {
           
                string query = "Select * From BottomGrid";
                using (var connection = _context.CreateConnection())
                {
                    var value = await connection.QueryAsync<ResultBottomGridDto>(query);
                    return value.ToList();
                }
            
        }

        public async Task<ResultBottomGridDto> GetByIdBottomGridAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}

using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

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

        public Task DeleteBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridsAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection=_context.CreateConnection())
            {   
                var values= await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetBottomGridByIdDto> GetBottomGridByIdAsync(int id)
        {
            string query = "Select * From BottomGrid WHERE BottomGridID=@bottomGridID ";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridByIdDto>(query,parameters);
                return values;
            }
        }

        public Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}

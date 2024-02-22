using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task  CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "Insert into WhoWeAreDetail (Title, Subtitle, Description1, Description2) values (@title, @subtitle, @description1, @description2)";
            using (var connection=_context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@title", createWhoWeAreDetailDto.Title);
                parameters.Add("@subtitle", createWhoWeAreDetailDto.Subtitle);
                parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
                parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
               await connection.ExecuteAsync(query, parameters);


            }
        }

        public async Task DeleteWhoWeAreDetailAsync(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whowearedetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);

                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID=@whowearedetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailid", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title , Subtitle=@subtitle, Description1=@description1, Description2=@description2 WHERE WhoWeAreDetailID=@whowearedetailid ";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            parameters.Add("@whowearedetailid", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            using (var _connection = _context.CreateConnection())
            {
                await _connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

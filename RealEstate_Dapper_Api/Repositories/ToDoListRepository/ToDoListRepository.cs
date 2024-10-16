using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public Task CreateToDoListAsync(CreateToDoListDto createToDoListDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoListAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList";
            using (var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList(); 
            }
            
        }

        public Task<GetByIdToDoListDto> GetToDoListByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoListAsync(UpdateToDoListDto updateToDoListDto)
        {
            throw new NotImplementedException();
        }
    }
}

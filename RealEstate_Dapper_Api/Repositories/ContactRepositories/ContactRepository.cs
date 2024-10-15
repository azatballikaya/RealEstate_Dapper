using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
           throw new NotImplementedException();
        }

        public Task DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultContactDto>> GetAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdContactDto> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultContactDto>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact order by ContactID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            throw new NotImplementedException();
        }
    }
}

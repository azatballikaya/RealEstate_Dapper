using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<ResultContactDto>> GetLast4ContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(int id);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<GetByIdContactDto> GetContactByIdAsync(int id);
    }
}

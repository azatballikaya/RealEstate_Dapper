using Dapper;
using RealEstate_Dapper_Api.DapperContext;
using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiverAsync(int id)
        {
            string query = "Select Top(3) MessageID,Name,Subject,Detail,SendDate,IsRead,UserImageUrl From Message inner join AppUser on Message.Sender=AppUser.UserID Where Receiver=@receiverID Order By SendDate Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverID", id);
            using (var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}

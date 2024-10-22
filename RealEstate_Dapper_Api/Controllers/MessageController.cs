using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInBoxLast3MessageListByReceiver(int id)
        {
            var values = await _messageRepository.GetInBoxLast3MessageListByReceiverAsync(id);
            return Ok(values);
        }
    }
}

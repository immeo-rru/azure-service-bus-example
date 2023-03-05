using Microsoft.AspNetCore.Mvc;
using ServiceBus.Producer.Models;
using ServiceBus.Producer.Services;

namespace ServiceBus.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagingController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public MessagingController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost("publish/text")]
        public async Task<IActionResult> PublishText()
        {
            using var reader = new StreamReader(Request.Body);
            var message = await reader.ReadToEndAsync();
            await _messagePublisher.Publish(message);
            return Ok();
        }

        [HttpPost("publish/order")]
        public async Task<IActionResult> PublishOrder([FromBody] OrderRequest request)
        {
            await _messagePublisher.Publish(request);
            return Ok();
        }

        [HttpPost("publish/contact")]
        public async Task<IActionResult> PublishContact([FromBody] ContactRequest request)
        {
            await _messagePublisher.Publish(request);
            return Ok();
        }


    }
}
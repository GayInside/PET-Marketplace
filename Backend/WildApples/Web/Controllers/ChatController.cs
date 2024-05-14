using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Commands.Chat;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController(IMediator mediator) : Controller
    {
        [HttpPost("CreateChat")]
        [Authorize]
        public async Task<IActionResult> CreateChat(CreateChatCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}

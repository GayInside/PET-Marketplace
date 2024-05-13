using Chat.Domain.Services;
using Chat.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers
{
    [ApiController]
    [Route("/chat/api/[controller]")]
    public class ChatController(ChattingService chattingService) : Controller 
    {
        [HttpGet("GetChat")]
        public async Task<IActionResult> GetChat(long id)
        {
            var chat = await chattingService.GetChat(id);

            return Ok(chat);
        }

        [HttpPost("CreateChat")]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatModel createModel)
        {
            var id = await chattingService.CreateChat(createModel.FirstUserId, createModel.FirstUserId);

            return Ok(id);
        }
    }
}

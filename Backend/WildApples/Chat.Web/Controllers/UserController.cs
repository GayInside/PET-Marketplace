using Chat.Domain.Entities;
using Chat.Domain.Services;
using Chat.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers
{
    [ApiController]
    [Route("/chat/api/[controller]")]
    public class UserController(UserService userService) : Controller
    {
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserModel userModel)
        {
            var user = new User()
            {
                MainId = userModel.MainId,
                Username = userModel.Username
            };

            await userService.Add(user);

            return Ok(user.Id);
        }
    }
}

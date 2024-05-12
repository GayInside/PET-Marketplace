using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Claims;
using Web.Models.Commands.Authorization;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IMediator _mediator)
    : Controller
{
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody]LoginCommand request)
    {
        try
        {
            var accountModel = await _mediator.Send(request);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, accountModel.Username),
                new Claim(ClaimTypes.Role, accountModel.Role.Name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateAccountCommand command)
    {
        try
        {
            await _mediator.Send(command);

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Something wrong with your data");
        }
    }
}

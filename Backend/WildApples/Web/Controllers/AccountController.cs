using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Models.Authorization;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IMediator _mediator)
    : Controller
{
    [HttpPost]
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
}

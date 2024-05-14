using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Commands.Publications;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController(IMediator mediator) : Controller
{
    [HttpGet("GetAllPublications")]
    public async Task<IActionResult> GetAllPublications([FromQuery]GetPublicationsWithPaginationCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("CreatePublication")]
    [Authorize]
    public async Task<IActionResult> CreatePublication([FromBody]CreatePublicationCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("GetPublication")]
    public async Task<IActionResult> GetPublication([FromQuery] GetPublicationCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("DeletePublication")]
    [Authorize]
    public async Task<IActionResult> DeletePublication([FromBody]DeletePublicationCommand command)
    {
        try
        {
            await mediator.Send(command);

            return Ok();
        }
        catch (Exception) 
        {
            return BadRequest("Access denied");
        }
    }

    [HttpPut("UpdatePublication")]
    [Authorize]
    public async Task<IActionResult> UpdatePublication([FromBody]UpdatePublicationCommand command)
    {
        try
        {
            await mediator.Send(command);

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Access denied");
        }
    }

    [HttpPut("AddToFavoirites")]
    [Authorize]
    public async Task<IActionResult> AddPubblicationToFavorites([FromBody]AddPublicationToFavoritesCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }
}

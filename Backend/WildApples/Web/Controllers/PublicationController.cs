using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Commands.Publications;

namespace Web.Controllers;

public class PublicationController(IMediator mediator) : Controller
{
    [HttpGet("GetAllPublications")]
    public async Task<IActionResult> GetAllPublications(GetPublicationsWithPaginationCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("CreatePublication")]
    [Authorize]
    public async Task<IActionResult> CreatePublication(CreatePublicationCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("GetPublication")]
    public async Task<IActionResult> GetPublication(GetPublicationCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("DeletePublication")]
    [Authorize]
    public async Task<IActionResult> DeletePublication(DeletePublicationCommand command)
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
    public async Task<IActionResult> UpdatePublication(UpdatePublicationCommand command)
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
    public async Task<IActionResult> AddPubblicationToFavorites(AddPublicationToFavoritesCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }
}

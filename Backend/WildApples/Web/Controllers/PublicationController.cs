using MediatR;
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

    [HttpGet("Test")]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}

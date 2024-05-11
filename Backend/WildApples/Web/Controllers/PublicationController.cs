﻿using MediatR;
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
}
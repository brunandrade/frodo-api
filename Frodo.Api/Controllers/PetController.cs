using Core.Api.Controllers;
using Frodo.Pets.Application.Commands;
using Frodo.Pets.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Frodo.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("pets")]
public class PetController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(PetModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromForm] CreatePetCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}

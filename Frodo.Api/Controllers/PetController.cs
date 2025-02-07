using Core.Api.Controllers;
using Frodo.Pets.Application.Commands;
using Frodo.Pets.Application.Extensions;
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
        => Ok(await _mediator.Send(request));

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(PetModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] UpdatePetRequest request)
        => Ok(await _mediator.Send(request.MapToCommand(id)));

    [HttpPost("{id}/add-vaccine")]
    [ProducesResponseType(typeof(PetModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreatePetVaccine([FromRoute] Guid id, [FromForm] CreatePetVaccineCommand request)
        => Ok(await _mediator.Send(request));

    [HttpDelete("{id}/remove-vaccine/{vaccineId}")]
    [ProducesResponseType(typeof(PetModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> RemovePetVaccine([FromRoute] Guid id, [FromRoute] Guid vaccineId)
    {
        return Ok(await _mediator.Send(new RemovePetVaccineCommand(id, vaccineId));
    }
}
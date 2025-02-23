using Core.Api.Controllers;
using Frodo.Users.Application.Commands;
using Frodo.Users.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Frodo.Api.Controllers;
[ApiVersion("1.0")]
[ApiController]
[Route("users")]
public class UserController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(UserModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        => Ok(await _mediator.Send(request));
}

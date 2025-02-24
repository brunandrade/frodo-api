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

    [HttpPut("{id}/verify-token")]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> VerifyToken([FromRoute] Guid id, [FromBody] VerifyUserRequest request)
        => Ok(await _mediator.Send(new VerifyUserCommand(id, request.Token)));

    [HttpPost("{id}/resend-verify-token")]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> ResendVerifyToken([FromRoute] Guid id)
        => Ok(await _mediator.Send(new ResendVerifyTokenCommand(id)));

    [HttpPost("/sign-in")]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SignIn([FromBody] string email)
        => Ok(await _mediator.Send(new SignInCommand(email)));
}
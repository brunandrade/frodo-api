using Core.Messaging.Messaging;
using Frodo.Users.Application.Models;

namespace Frodo.Users.Application.Commands;

public record CreateUserCommand(
    string Name,
    string Email,
    string Password) : ICommand<UserModel>;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserModel>
{
    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

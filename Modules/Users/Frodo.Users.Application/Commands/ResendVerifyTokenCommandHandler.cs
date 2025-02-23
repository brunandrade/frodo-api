using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Users.Domain;
using MediatR;

namespace Frodo.Users.Application.Commands;

public record ResendVerifyTokenCommand(Guid UserId) : ICommand;

public class ResendVerifyTokenCommandHandler : ICommandHandler<ResendVerifyTokenCommand>
{
    private readonly IUserRepository _userRepository;

    public ResendVerifyTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(ResendVerifyTokenCommand request, CancellationToken cancellationToken)
    {
        var includes = new List<string> { "VerificationTokens" };
        var user = await _userRepository.GetByIdAsync<User>(request.UserId, includes, cancellationToken)
            ?? throw new BusinessException("VerifyUser", "Usuário não encontrado.");

        user.RemoveAllTokens();
        user.AddVerificationToken();

        _userRepository.Update(user);
        await _userRepository.IUnitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
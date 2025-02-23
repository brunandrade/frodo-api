using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Users.Domain;
using MediatR;

namespace Frodo.Users.Application.Commands;

public record VerifyUserRequest(string Token) : ICommand;

public record VerifyUserCommand(Guid UserId, string Token) : ICommand;

public class VerifyUserCommandHandler : ICommandHandler<VerifyUserCommand>
{
    private readonly IUserRepository _userRepository;

    public VerifyUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
    {
        var includes = new List<string> { "VerificationTokens" };
        var user = await _userRepository.GetByIdAsync<User>(request.UserId, includes, cancellationToken)
            ?? throw new BusinessException("VerifyUser", "Usuário não encontrado.");

        var token = user.VerificationTokens
            .FirstOrDefault(v => v.VerificationToken == request.Token && !v.IsExpired() && !v.DeletedIn.HasValue)
            ?? throw new BusinessException("VerifyUser", "Token não encontrado ou expirado.");

        user.VerifyToken(token.VerificationToken);

        _userRepository.Update(user);
        await _userRepository.IUnitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
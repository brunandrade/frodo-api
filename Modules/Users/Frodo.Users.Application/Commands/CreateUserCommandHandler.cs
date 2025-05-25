using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Users.Application.Models;
using Frodo.Users.Application.Specifications;
using Frodo.Users.Domain;
using Mapster;

namespace Frodo.Users.Application.Commands;

public record CreateUserCommand(string Name,string Email, string UserName, string Password, string PasswordConfirmation) : ICommand<UserModel>;

public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand, UserModel>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await EnsureEmailIsUniqueAsync(request.Email, cancellationToken);
        await EnsureUsernameIsUniqueAsync(request.UserName, cancellationToken);
        EnsurePasswordsMatch(request.Password, request.PasswordConfirmation);

        var user = new User(request.Name, request.Email, request.UserName, request.Password);

        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.IUnitOfWork.Commit(cancellationToken);

        return user.Adapt<UserModel>();
    }

    private async Task EnsureEmailIsUniqueAsync(string email, CancellationToken cancellationToken)
    {
        var users = await _userRepository.FindAsync(new GetUserSpecificationByEmail(email), cancellationToken);

        if (users?.Any() == true)
        {
            throw new BusinessException("CreateUser", "Já existe um usuário com este email.");
        }
    }

    private async Task EnsureUsernameIsUniqueAsync(string userName, CancellationToken cancellationToken)
    {
        var users = await _userRepository.FindAsync(new GetUserSpecificationByUserName(userName), cancellationToken);

        if (users?.Any() == true)
        {
            throw new BusinessException("CreateUser", "Já existe um usuário com este usuário.");
        }
    }

    private static void EnsurePasswordsMatch(string password, string confirmation)
    {
        if (password != confirmation)
        {
            throw new BusinessException("CreateUser", "Senha e confirmação de senha são diferentes.");
        }
    }
}
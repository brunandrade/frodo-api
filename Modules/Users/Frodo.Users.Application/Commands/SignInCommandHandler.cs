using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Users.Application.Models;
using Frodo.Users.Application.Specifications;
using Frodo.Users.Domain;
using Mapster;

namespace Frodo.Users.Application.Commands;

public record SignInCommand(string Email) : ICommand<UserModel>;

public class SignInCommandHandler : ICommandHandler<SignInCommand, UserModel>
{
    private readonly IUserRepository _userRepository;

    public SignInCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var specification = new UserSpecification(request.Email);
        var users = await _userRepository.FindAsync(specification, cancellationToken);

        if (users?.Any() == false)
        {
            throw new BusinessException("SignIn", "Usuário não encontrado.");
        }

        var user = users.FirstOrDefault();
        user.AddVerificationToken();

        _userRepository.Update(user);
        await _userRepository.IUnitOfWork.Commit(cancellationToken);

        var data = user.Adapt<UserModel>();
        return data;
    }
}

using Core.Messaging.Messaging;
using Core.Validations.Exceptions;
using Frodo.Integrations.SMS;
using Frodo.Users.Application.Models;
using Frodo.Users.Application.Specifications;
using Frodo.Users.Domain;
using Mapster;

namespace Frodo.Users.Application.Commands;

 public record CreateUserCommand(string Name,string Email,
    string Phone) : ICommand<UserModel>;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserModel>
{
    private readonly IUserRepository _userRepository;
    private readonly ISendSMSService _sendSMSService;

    public CreateUserCommandHandler(IUserRepository userRepository, ISendSMSService sendSMSService)
    {
        _userRepository = userRepository;
        _sendSMSService = sendSMSService;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var specification = new UserSpecification(request.Email);
        var users = await _userRepository.FindAsync(specification, cancellationToken);

        if (users?.Any() == true)
        {
            throw new BusinessException("CreateUser", "Já existe um usuário com este email.");
        }

        var user = new User(request.Name, request.Email, request.Phone);
        var verificationToken = user.VerificationTokens.FirstOrDefault(v => !v.IsExpired());

        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.IUnitOfWork.Commit(cancellationToken);

        //await _sendSMSService.SendSmsAsync("COM3", request.Phone, verificationToken!.VerificationToken);

        var data = user.Adapt<UserModel>();
        return data;
    }
}
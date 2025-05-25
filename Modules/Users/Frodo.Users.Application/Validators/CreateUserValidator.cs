using FluentValidation;
using Frodo.Users.Application.Commands;

namespace Frodo.Users.Application.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Nome é obrigatório")
            .NotEmpty().WithMessage("Nome é obrigatório");

        RuleFor(x => x.UserName)
            .NotNull().WithMessage("Nome de usuário é obrigatório")
            .NotEmpty().WithMessage("Nome de usuário é obrigatório");

        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email é obrigatório")
            .NotEmpty().WithMessage("Email é obrigatório");

        RuleFor(x => x.Password)
            .NotNull().WithMessage("Senha é obrigatório")
            .NotEmpty().WithMessage("Senha é obrigatório");

        RuleFor(x => x.PasswordConfirmation)
            .NotNull().WithMessage("Confirmação de senha é obrigatório")
            .NotEmpty().WithMessage("Confirmação de senha é obrigatório");
    }
}
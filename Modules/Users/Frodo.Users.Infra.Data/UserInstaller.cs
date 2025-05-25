using FluentValidation;
using Frodo.Users.Application;
using Frodo.Users.Application.Commands;
using Frodo.Users.Application.Validators;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Users.Infra.Data;

public static class UserInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ApplicationAssemblyReference).Assembly);

        //Validators
        services.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
    }
}
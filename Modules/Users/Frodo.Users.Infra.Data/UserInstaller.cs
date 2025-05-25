using Frodo.Users.Application;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Users.Infra.Data;

public static class UserInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ApplicationAssemblyReference).Assembly);
    }
}
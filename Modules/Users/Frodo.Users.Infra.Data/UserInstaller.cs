using Frodo.Users.Application;
using Frodo.Users.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Users.Infra.Data;

public static class UserInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ApplicationAssemblyReference).Assembly);

        services.AddScoped<IUserRepository, UserRepository>(provider =>
        {
            var contexto = provider.GetRequiredService<UserContext>();
            return new UserRepository(contexto);
        });

        services.AddDbContext<UserContext>(options => options
            .UseSqlServer(configuration
                .GetConnectionString("sqlserver"), x => x
                    .MigrationsAssembly(typeof(UserContext).Assembly.FullName)));
    }
}
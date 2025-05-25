using Frodo.Pets.Domain.Interfaces;
using Frodo.Pets.Infra.Data;
using Frodo.Users.Domain;
using Frodo.Users.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Infra.Data;

public static class InfraDataInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IUserRepository, UserRepository>(provider =>
        {
            var contexto = provider.GetRequiredService<FrodoContext>();
            return new UserRepository(contexto);
        });


        services.AddScoped<IPetRepository, PetRepository>(provider =>
        {
            var contexto = provider.GetRequiredService<FrodoContext>();
            return new PetRepository(contexto);
        });

        services.AddDbContext<FrodoContext>(options => options
            .UseNpgsql(configuration
                .GetConnectionString("database"), x => x
                    .MigrationsAssembly(typeof(FrodoContext).Assembly.FullName)));
    }
}
using Frodo.Pets.Application;
using Frodo.Pets.Domain.Interfaces;
using Frodo.Pets.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Pets.Infra.Data;

public static class PetInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ApplicationAssemblyReference).Assembly);
        services.AddScoped<IPetFactory, PetFactory>();

        services.AddScoped<IPetRepository, PetRepository>(provider =>
        {
            var contexto = provider.GetRequiredService<PetContext>();
            return new PetRepository(contexto);
        });

        services.AddDbContext<PetContext>(options => options
            .UseSqlServer(configuration
                .GetConnectionString("sqlserver"), x => x
                    .MigrationsAssembly(typeof(PetContext).Assembly.FullName)));
    }
}
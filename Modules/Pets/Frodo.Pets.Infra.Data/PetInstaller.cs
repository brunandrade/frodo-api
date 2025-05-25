using Frodo.Pets.Application;
using Frodo.Pets.Domain.Interfaces;
using Frodo.Pets.Domain.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Pets.Infra.Data;

public static class PetInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ApplicationAssemblyReference).Assembly);
        services.AddScoped<IPetFactory, PetFactory>();
        services.AddScoped<ICreatePetVaccineService, CreatePetVaccineService>();
    }
}
using Core.Api.Middlewares;
using Frodo.Infra.Data;
using Frodo.Integrations;
using Frodo.Pets.Infra.Data;
using Frodo.Users.Infra.Data;

namespace Frodo.Api;

public static class FrodoInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(provider =>
        {
            var logger = provider.GetRequiredService<ILogger<ExceptionHandlerMiddleware>>();
            var projectName = "Frodo - API";
            return new ExceptionHandlerMiddleware(logger, projectName);
        });

        InfraDataInstaller.Install(services, configuration);
        IntegrationsInstaller.Install(services, configuration);
        PetInstaller.Install(services, configuration);
        UserInstaller.Install(services, configuration);
    }
}
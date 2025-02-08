using Frodo.Pets.Infra.Data;

namespace Frodo.Api;

public static class FrodoInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        PetInstaller.Install(services, configuration);
    }
}
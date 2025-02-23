using Frodo.Pets.Infra.Data;
using Frodo.Users.Infra.Data;

namespace Frodo.Api;

public static class FrodoInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        PetInstaller.Install(services, configuration);
        UserInstaller.Install(services, configuration);
    }
}
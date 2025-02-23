using Frodo.Integrations.SMS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frodo.Integrations;

public static class IntegrationsInstaller
{
    public static void Install(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISendSMSService, SendSMSService>();
    }
}
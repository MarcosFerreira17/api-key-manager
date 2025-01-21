using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Packages.Extensions;
public class ServiceExtensions
{
    public static void AddApiKeyAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ApiKeyScopeFilter>();
        });

        string providerUrl = configuration.GetValue<string>("ApiKeyManager:ProviderUrl");

        if (string.IsNullOrEmpty(providerUrl))
        {
            throw new InvalidOperationException("ApiKeyManager:ProviderUrl is not configured. Please set it in appsettings.json.");
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace Infrastructure.Packages;

public class ApiKeyScopeFilter : IAsyncActionFilter
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public ApiKeyScopeFilter(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var httpContext = context.HttpContext;
        var apiKey = httpContext.Request.Headers["x-api-key"].FirstOrDefault();

        if (string.IsNullOrEmpty(apiKey))
        {
            context.Result = new UnauthorizedObjectResult("API Key is missing");
            return;
        }

        var requiredScopes = context.ActionDescriptor.EndpointMetadata
            .OfType<RequireScopesAttribute>()
            .FirstOrDefault()?.Scopes;

        if (requiredScopes == null || !requiredScopes.Any())
        {
            await next();
            return;
        }

        var providerUrl = _configuration.GetValue<string>("ApiKeyManager:ProviderUrl");

        if (string.IsNullOrEmpty(providerUrl))
        {
            throw new InvalidOperationException("ApiKeyManager:ProviderUrl is not configured in appsettings.");
        }

        var hasAccess = await ValidateApiKeyAndScopesAsync(apiKey, requiredScopes, providerUrl);

        if (!hasAccess)
        {
            context.Result = new ForbidResult("Insufficient permissions");
            return;
        }

        await next();
    }

    private async Task<bool> ValidateApiKeyAndScopesAsync(string apiKey, string[] requiredScopes, string providerUrl)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"{providerUrl}/validate?apiKey={apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var apiKeyInfo = JsonSerializer.Deserialize<ApiKeyInfo>(responseBody);

        return requiredScopes.All(scope => apiKeyInfo.Scopes.Contains(scope));
    }
}

public class ApiKeyInfo
{
    public string ApiKey { get; set; }
    public List<string> Scopes { get; set; }
}

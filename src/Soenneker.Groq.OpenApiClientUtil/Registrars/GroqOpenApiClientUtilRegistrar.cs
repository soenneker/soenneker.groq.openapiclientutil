using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Groq.HttpClients.Registrars;
using Soenneker.Groq.OpenApiClientUtil.Abstract;

namespace Soenneker.Groq.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class GroqOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds both <see cref="IGroqOpenApiClientUtil"/> and the underlying HTTP client provider as singleton services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGroqOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGroqOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IGroqOpenApiClientUtil, GroqOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IGroqOpenApiClientUtil"/> as a scoped service over the singleton HTTP client provider.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGroqOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddGroqOpenApiHttpClientAsSingleton()
                .TryAddScoped<IGroqOpenApiClientUtil, GroqOpenApiClientUtil>();

        return services;
    }
}

using Soenneker.Groq.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Groq.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily created Groq OpenAPI client over the shared Groq HTTP client.
/// </summary>
public interface IGroqOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The client cached for this utility's lifetime.</returns>
    ValueTask<GroqOpenApiClient> Get(CancellationToken cancellationToken = default);
}

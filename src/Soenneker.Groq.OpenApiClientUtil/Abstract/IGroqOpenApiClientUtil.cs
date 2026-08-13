using Soenneker.Groq.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Groq.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IGroqOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<GroqOpenApiClient> Get(CancellationToken cancellationToken = default);
}

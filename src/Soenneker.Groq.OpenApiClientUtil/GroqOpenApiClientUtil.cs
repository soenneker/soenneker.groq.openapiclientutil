using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Groq.HttpClients.Abstract;
using Soenneker.Groq.OpenApiClientUtil.Abstract;
using Soenneker.Groq.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Groq.OpenApiClientUtil;

/// <inheritdoc cref="IGroqOpenApiClientUtil" />
public sealed class GroqOpenApiClientUtil : IGroqOpenApiClientUtil
{
    private readonly AsyncSingleton<GroqOpenApiClient> _client;

    public GroqOpenApiClientUtil(IGroqOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<GroqOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new GroqOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<GroqOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}

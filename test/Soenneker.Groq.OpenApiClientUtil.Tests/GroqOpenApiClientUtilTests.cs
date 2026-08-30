using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Groq.HttpClients.Abstract;
using Soenneker.Groq.OpenApiClientUtil.Abstract;
using Soenneker.Groq.OpenApiClientUtil.Registrars;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Groq.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class GroqOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IGroqOpenApiClientUtil _openapiclientutil;

    public GroqOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IGroqOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_utility_keeps_http_client_singleton()
    {
        var services = new ServiceCollection();

        services.AddGroqOpenApiClientUtilAsScoped();

        ServiceDescriptor httpClient = services.Single(descriptor => descriptor.ServiceType == typeof(IGroqOpenApiHttpClient));
        ServiceDescriptor clientUtil = services.Single(descriptor => descriptor.ServiceType == typeof(IGroqOpenApiClientUtil));

        await Assert.That(httpClient.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(clientUtil.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}

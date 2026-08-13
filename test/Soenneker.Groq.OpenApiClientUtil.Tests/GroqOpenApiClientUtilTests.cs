using Soenneker.Groq.OpenApiClientUtil.Abstract;
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
}

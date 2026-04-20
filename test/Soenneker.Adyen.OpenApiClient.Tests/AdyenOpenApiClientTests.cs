using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Adyen.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class AdyenOpenApiClientTests : FixturedUnitTest
{
    public AdyenOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}

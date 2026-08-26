using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class RateLimitServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.RateLimits.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

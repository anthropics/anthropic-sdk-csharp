using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization;

public class RateLimitServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.RateLimits.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

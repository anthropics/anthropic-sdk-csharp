using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization.Workspaces;

public class RateLimitServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Workspaces.RateLimits.List(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

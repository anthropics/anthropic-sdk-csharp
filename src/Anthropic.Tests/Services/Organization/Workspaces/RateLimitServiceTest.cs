using System.Threading.Tasks;
using Anthropic.Models.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Services.Organization.Workspaces;

public class RateLimitServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var workspaceRateLimit = await this.client.Organization.Workspaces.RateLimits.Update(
            "rate_limit_id",
            new()
            {
                WorkspaceID = "workspace_id",
                Limits = [new() { Type = WorkspaceRateLimitType.FastItpmca, Value = 0 }],
            },
            TestContext.Current.CancellationToken
        );
        workspaceRateLimit.Validate();
    }

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

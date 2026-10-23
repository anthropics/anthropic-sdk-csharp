using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Services.Beta.Organization.Workspaces;

public class RateLimitServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var betaWorkspaceRateLimit = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Workspaces.RateLimits.Update(
                "rate_limit_id",
                new()
                {
                    WorkspaceID = "workspace_id",
                    Limits = [new() { Type = BetaWorkspaceRateLimitType.FastItpmca, Value = 0 }],
                },
                TestContext.Current.CancellationToken
            );
        betaWorkspaceRateLimit.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Workspaces.RateLimits.List(
                "workspace_id",
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}

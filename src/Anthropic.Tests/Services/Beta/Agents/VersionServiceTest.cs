using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Agents;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Agents.Versions.List(
            "agent_011CZkYpogX7uDKUyvBTophP",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

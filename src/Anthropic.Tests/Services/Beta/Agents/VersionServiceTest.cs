using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Agents;

public class VersionServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Agents.Versions.List(
                "agent_011CZkYpogX7uDKUyvBTophP",
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}

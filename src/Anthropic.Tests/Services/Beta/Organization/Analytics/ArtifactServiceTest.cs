using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class ArtifactServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Analytics.Artifacts.List(
            new() { Date = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

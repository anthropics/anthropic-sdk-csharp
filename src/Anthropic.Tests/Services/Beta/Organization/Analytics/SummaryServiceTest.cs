using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class SummaryServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Analytics.Summaries.List(
            new() { StartingDate = "2019-12-27" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

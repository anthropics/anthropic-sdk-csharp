using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class ConnectorServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Analytics.Connectors.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

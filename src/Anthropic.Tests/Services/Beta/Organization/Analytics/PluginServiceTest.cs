using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class PluginServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Analytics.Plugins.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}

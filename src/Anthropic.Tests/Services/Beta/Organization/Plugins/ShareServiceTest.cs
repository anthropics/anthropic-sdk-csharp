using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Plugins;

public class ShareServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Plugins.Shares.List(
                "plugin_id",
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}

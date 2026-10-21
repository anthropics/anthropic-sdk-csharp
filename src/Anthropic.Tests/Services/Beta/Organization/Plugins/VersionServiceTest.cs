using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Plugins;

public class VersionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaPluginVersion = await this.client.Beta.Organization.Plugins.Versions.Create(
            "plugin_id",
            new() { Files = [Encoding.UTF8.GetBytes("Example data")] },
            TestContext.Current.CancellationToken
        );
        betaPluginVersion.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaPluginVersion = await this.client.Beta.Organization.Plugins.Versions.Retrieve(
            "version",
            new() { PluginID = "plugin_id" },
            TestContext.Current.CancellationToken
        );
        betaPluginVersion.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Plugins.Versions.List(
            "plugin_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Download_Works()
    {
        await this.client.Beta.Organization.Plugins.Versions.Download(
            "version",
            new() { PluginID = "plugin_id" },
            TestContext.Current.CancellationToken
        );
    }
}

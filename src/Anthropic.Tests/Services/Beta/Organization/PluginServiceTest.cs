using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class PluginServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaPlugin = await this.client.Beta.Organization.Plugins.Create(
            new() { Files = [Encoding.UTF8.GetBytes("Example data")] },
            TestContext.Current.CancellationToken
        );
        betaPlugin.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaPlugin = await this.client.Beta.Organization.Plugins.Retrieve(
            "plugin_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaPlugin.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaPlugin = await this.client.Beta.Organization.Plugins.Update(
            "plugin_id",
            new() { ServedVersionID = "pluginver_01KaZmQpRsTuVwXyZ2b4c6d8" },
            TestContext.Current.CancellationToken
        );
        betaPlugin.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Plugins.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedPlugin = await this.client.Beta.Organization.Plugins.Delete(
            "plugin_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaDeletedPlugin.Validate();
    }
}

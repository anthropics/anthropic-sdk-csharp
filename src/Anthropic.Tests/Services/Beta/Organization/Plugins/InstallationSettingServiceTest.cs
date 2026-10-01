using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Tests.Services.Beta.Organization.Plugins;

public class InstallationSettingServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Plugins.InstallationSettings.List(
            "plugin_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var betaDeletedPluginInstallationSetting =
            await this.client.Beta.Organization.Plugins.InstallationSettings.Remove(
                "target",
                new() { PluginID = "plugin_id" },
                TestContext.Current.CancellationToken
            );
        betaDeletedPluginInstallationSetting.Validate();
    }

    [Fact]
    public async Task Set_Works()
    {
        var betaPluginInstallationSetting =
            await this.client.Beta.Organization.Plugins.InstallationSettings.Set(
                "target",
                new()
                {
                    PluginID = "plugin_id",
                    InstallationPreference = InstallationPreference.Required,
                },
                TestContext.Current.CancellationToken
            );
        betaPluginInstallationSetting.Validate();
    }
}

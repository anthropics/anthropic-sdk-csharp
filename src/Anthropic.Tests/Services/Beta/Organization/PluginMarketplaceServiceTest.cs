using System.Text;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Services.Beta.Organization;

public class PluginMarketplaceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaPluginMarketplace = await this.client.Beta.Organization.PluginMarketplaces.Retrieve(
            "marketplace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaPluginMarketplace.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaPluginMarketplace = await this.client.Beta.Organization.PluginMarketplaces.Update(
            "marketplace_id",
            new() { DefaultInstallationPreference = DefaultInstallationPreference.Available },
            TestContext.Current.CancellationToken
        );
        betaPluginMarketplace.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.PluginMarketplaces.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task ValidateArchive_Works()
    {
        var betaPluginMarketplaceValidationReport =
            await this.client.Beta.Organization.PluginMarketplaces.ValidateArchive(
                new() { Archive = Encoding.UTF8.GetBytes("Example data") },
                TestContext.Current.CancellationToken
            );
        betaPluginMarketplaceValidationReport.Validate();
    }

    [Fact]
    public async Task ValidateRepository_Works()
    {
        var betaPluginMarketplaceValidationReport =
            await this.client.Beta.Organization.PluginMarketplaces.ValidateRepository(
                new() { RepositoryUrl = "https://github.com/example-org/example-marketplace" },
                TestContext.Current.CancellationToken
            );
        betaPluginMarketplaceValidationReport.Validate();
    }
}

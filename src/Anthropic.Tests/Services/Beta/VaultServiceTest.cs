using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class VaultServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsVault = await this.client.Beta.Vaults.Create(
            new() { DisplayName = "Example vault" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsVault.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsVault = await this.client.Beta.Vaults.Retrieve(
            "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsVault.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsVault = await this.client.Beta.Vaults.Update(
            "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsVault.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Vaults.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaManagedAgentsDeletedVault = await this.client.Beta.Vaults.Delete(
            "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeletedVault.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsVault = await this.client.Beta.Vaults.Archive(
            "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsVault.Validate();
    }
}

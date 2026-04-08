using System.Threading.Tasks;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Services.Beta.Vaults;

public class CredentialServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsCredential = await this.client.Beta.Vaults.Credentials.Create(
            "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            new()
            {
                Auth = new BetaManagedAgentsStaticBearerCreateParams()
                {
                    Token = "bearer_exampletoken",
                    McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                    Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
                },
            },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsCredential.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsCredential = await this.client.Beta.Vaults.Credentials.Retrieve(
            "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            new() { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsCredential.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsCredential = await this.client.Beta.Vaults.Credentials.Update(
            "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            new() { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsCredential.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Vaults.Credentials.List(
            "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaManagedAgentsDeletedCredential = await this.client.Beta.Vaults.Credentials.Delete(
            "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            new() { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeletedCredential.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsCredential = await this.client.Beta.Vaults.Credentials.Archive(
            "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            new() { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsCredential.Validate();
    }
}

using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Federation;

public class IssuerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaFederationIssuer = await this.client.Beta.Organization.Federation.Issuers.Create(
            new() { IssuerUrl = "x", Name = "x" },
            TestContext.Current.CancellationToken
        );
        betaFederationIssuer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaFederationIssuer = await this.client.Beta.Organization.Federation.Issuers.Retrieve(
            "federation_issuer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaFederationIssuer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaFederationIssuer = await this.client.Beta.Organization.Federation.Issuers.Update(
            "federation_issuer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaFederationIssuer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Federation.Issuers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaFederationIssuer = await this.client.Beta.Organization.Federation.Issuers.Archive(
            "federation_issuer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaFederationIssuer.Validate();
    }
}

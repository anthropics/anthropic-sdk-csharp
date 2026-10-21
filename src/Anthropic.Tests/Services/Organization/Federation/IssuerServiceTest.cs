using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization.Federation;

public class IssuerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var federationIssuer = await this.client.Organization.Federation.Issuers.Create(
            new() { IssuerUrl = "x", Name = "x" },
            TestContext.Current.CancellationToken
        );
        federationIssuer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var federationIssuer = await this.client.Organization.Federation.Issuers.Retrieve(
            "federation_issuer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        federationIssuer.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var federationIssuer = await this.client.Organization.Federation.Issuers.Update(
            "federation_issuer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        federationIssuer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Federation.Issuers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var federationIssuer = await this.client.Organization.Federation.Issuers.Archive(
            "federation_issuer_id",
            new(),
            TestContext.Current.CancellationToken
        );
        federationIssuer.Validate();
    }
}

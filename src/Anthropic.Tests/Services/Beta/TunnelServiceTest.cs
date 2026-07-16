using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class TunnelServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaTunnel = await this.client.Beta.Tunnels.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        betaTunnel.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task Retrieve_Works()
    {
        var betaTunnel = await this.client.Beta.Tunnels.Retrieve(
            "tunnel_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaTunnel.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Tunnels.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaTunnel = await this.client.Beta.Tunnels.Archive(
            "tunnel_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaTunnel.Validate();
    }

    [Fact]
    public async Task RevealToken_Works()
    {
        var betaTunnelToken = await this.client.Beta.Tunnels.RevealToken(
            "tunnel_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaTunnelToken.Validate();
    }

    [Fact]
    public async Task RotateToken_Works()
    {
        var betaTunnelToken = await this.client.Beta.Tunnels.RotateToken(
            "tunnel_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaTunnelToken.Validate();
    }
}

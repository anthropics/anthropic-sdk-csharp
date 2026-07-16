using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Tunnels;

public class CertificateServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaTunnelCertificate = await this.client.Beta.Tunnels.Certificates.Create(
            "tunnel_id",
            new() { CaCertificatePem = "ca_certificate_pem" },
            TestContext.Current.CancellationToken
        );
        betaTunnelCertificate.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task Retrieve_Works()
    {
        var betaTunnelCertificate = await this.client.Beta.Tunnels.Certificates.Retrieve(
            "certificate_id",
            new() { TunnelID = "tunnel_id" },
            TestContext.Current.CancellationToken
        );
        betaTunnelCertificate.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Tunnels.Certificates.List(
            "tunnel_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaTunnelCertificate = await this.client.Beta.Tunnels.Certificates.Archive(
            "certificate_id",
            new() { TunnelID = "tunnel_id" },
            TestContext.Current.CancellationToken
        );
        betaTunnelCertificate.Validate();
    }
}

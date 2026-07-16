using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Tests.Models.Beta.Tunnels.Certificates;

public class CertificateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CertificateCreateParams
        {
            TunnelID = "tunnel_id",
            CaCertificatePem = "ca_certificate_pem",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedTunnelID = "tunnel_id";
        string expectedCaCertificatePem = "ca_certificate_pem";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedTunnelID, parameters.TunnelID);
        Assert.Equal(expectedCaCertificatePem, parameters.CaCertificatePem);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CertificateCreateParams
        {
            TunnelID = "tunnel_id",
            CaCertificatePem = "ca_certificate_pem",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CertificateCreateParams
        {
            TunnelID = "tunnel_id",
            CaCertificatePem = "ca_certificate_pem",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        CertificateCreateParams parameters = new()
        {
            TunnelID = "tunnel_id",
            CaCertificatePem = "ca_certificate_pem",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/tunnels/tunnel_id/certificates?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CertificateCreateParams parameters = new()
        {
            TunnelID = "tunnel_id",
            CaCertificatePem = "ca_certificate_pem",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["mcp-tunnels-2026-06-22", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CertificateCreateParams
        {
            TunnelID = "tunnel_id",
            CaCertificatePem = "ca_certificate_pem",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        CertificateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

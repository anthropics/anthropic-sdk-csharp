using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Tests.Models.Beta.Tunnels.Certificates;

public class CertificateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CertificateRetrieveParams
        {
            TunnelID = "tunnel_id",
            CertificateID = "certificate_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedTunnelID = "tunnel_id";
        string expectedCertificateID = "certificate_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedTunnelID, parameters.TunnelID);
        Assert.Equal(expectedCertificateID, parameters.CertificateID);
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
        var parameters = new CertificateRetrieveParams
        {
            TunnelID = "tunnel_id",
            CertificateID = "certificate_id",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CertificateRetrieveParams
        {
            TunnelID = "tunnel_id",
            CertificateID = "certificate_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        CertificateRetrieveParams parameters = new()
        {
            TunnelID = "tunnel_id",
            CertificateID = "certificate_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/tunnels/tunnel_id/certificates/certificate_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CertificateRetrieveParams parameters = new()
        {
            TunnelID = "tunnel_id",
            CertificateID = "certificate_id",
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
        var parameters = new CertificateRetrieveParams
        {
            TunnelID = "tunnel_id",
            CertificateID = "certificate_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        CertificateRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

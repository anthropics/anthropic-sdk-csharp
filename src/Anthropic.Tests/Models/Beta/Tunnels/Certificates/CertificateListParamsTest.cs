using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Tests.Models.Beta.Tunnels.Certificates;

public class CertificateListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CertificateListParams
        {
            TunnelID = "tunnel_id",
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedTunnelID = "tunnel_id";
        bool expectedIncludeArchived = true;
        int expectedLimit = 0;
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedTunnelID, parameters.TunnelID);
        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
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
        var parameters = new CertificateListParams { TunnelID = "tunnel_id" };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CertificateListParams
        {
            TunnelID = "tunnel_id",

            // Null should be interpreted as omitted for these properties
            IncludeArchived = null,
            Limit = null,
            Page = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        CertificateListParams parameters = new()
        {
            TunnelID = "tunnel_id",
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/tunnels/tunnel_id/certificates?beta=true&include_archived=true&limit=0&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CertificateListParams parameters = new()
        {
            TunnelID = "tunnel_id",
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
        var parameters = new CertificateListParams
        {
            TunnelID = "tunnel_id",
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        CertificateListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

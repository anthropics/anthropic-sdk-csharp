using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Tunnels;

namespace Anthropic.Tests.Models.Beta.Tunnels;

public class TunnelRotateTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TunnelRotateTokenParams
        {
            TunnelID = "tunnel_id",
            Reason = "reason",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedTunnelID = "tunnel_id";
        string expectedReason = "reason";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedTunnelID, parameters.TunnelID);
        Assert.Equal(expectedReason, parameters.Reason);
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
        var parameters = new TunnelRotateTokenParams { TunnelID = "tunnel_id", Reason = "reason" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TunnelRotateTokenParams
        {
            TunnelID = "tunnel_id",
            Reason = "reason",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TunnelRotateTokenParams
        {
            TunnelID = "tunnel_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TunnelRotateTokenParams
        {
            TunnelID = "tunnel_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Reason = null,
        };

        Assert.Null(parameters.Reason);
        Assert.True(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        TunnelRotateTokenParams parameters = new() { TunnelID = "tunnel_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/tunnels/tunnel_id/rotate_token?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TunnelRotateTokenParams parameters = new()
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
        var parameters = new TunnelRotateTokenParams
        {
            TunnelID = "tunnel_id",
            Reason = "reason",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        TunnelRotateTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

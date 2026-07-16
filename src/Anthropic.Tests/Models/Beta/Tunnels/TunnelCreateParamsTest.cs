using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Tunnels;

namespace Anthropic.Tests.Models.Beta.Tunnels;

public class TunnelCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TunnelCreateParams
        {
            DisplayName = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedDisplayName = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedDisplayName, parameters.DisplayName);
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
        var parameters = new TunnelCreateParams { DisplayName = "x" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TunnelCreateParams
        {
            DisplayName = "x",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TunnelCreateParams
        {
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TunnelCreateParams
        {
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void Url_Works()
    {
        TunnelCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/tunnels?beta=true"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TunnelCreateParams parameters = new() { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["mcp-tunnels-2026-06-22", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TunnelCreateParams
        {
            DisplayName = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        TunnelCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

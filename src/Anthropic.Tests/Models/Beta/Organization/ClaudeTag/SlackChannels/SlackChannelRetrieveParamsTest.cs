using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.SlackChannels;

public class SlackChannelRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SlackChannelRetrieveParams
        {
            ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
            IncludeInherited = true,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedID = "slch_01SvpyRQK3nN6eH9uhRA7n1q";
        bool expectedIncludeInherited = true;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIncludeInherited, parameters.IncludeInherited);
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
        var parameters = new SlackChannelRetrieveParams { ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q" };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SlackChannelRetrieveParams
        {
            ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",

            // Null should be interpreted as omitted for these properties
            IncludeInherited = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new SlackChannelRetrieveParams
        {
            ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
            IncludeInherited = true,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            IncludeInherited = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        SlackChannelRetrieveParams parameters = new()
        {
            ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
            IncludeInherited = true,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_tag/slack_channels/slch_01SvpyRQK3nN6eH9uhRA7n1q?include_inherited=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SlackChannelRetrieveParams parameters = new()
        {
            ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,experimental-claude-tag-2026-10-21"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SlackChannelRetrieveParams
        {
            ID = "slch_01SvpyRQK3nN6eH9uhRA7n1q",
            IncludeInherited = true,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SlackChannelRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

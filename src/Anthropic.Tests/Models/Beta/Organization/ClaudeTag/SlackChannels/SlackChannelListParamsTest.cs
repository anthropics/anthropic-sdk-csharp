using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.SlackChannels;

public class SlackChannelListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SlackChannelListParams
        {
            SlackWorkspaceID = "slack_workspace_id",
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackChannelID = "slack_channel_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSlackWorkspaceID = "slack_workspace_id";
        bool expectedIncludeInherited = true;
        int expectedLimit = 0;
        string expectedPage = "page";
        string expectedSlackChannelID = "slack_channel_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedSlackWorkspaceID, parameters.SlackWorkspaceID);
        Assert.Equal(expectedIncludeInherited, parameters.IncludeInherited);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSlackChannelID, parameters.SlackChannelID);
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
        var parameters = new SlackChannelListParams { SlackWorkspaceID = "slack_workspace_id" };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SlackChannelID);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_channel_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SlackChannelListParams
        {
            SlackWorkspaceID = "slack_workspace_id",

            // Null should be interpreted as omitted for these properties
            IncludeInherited = null,
            Limit = null,
            Page = null,
            SlackChannelID = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SlackChannelID);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_channel_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new SlackChannelListParams
        {
            SlackWorkspaceID = "slack_workspace_id",
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackChannelID = "slack_channel_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            IncludeInherited = null,
            Limit = null,
            Page = null,
            SlackChannelID = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SlackChannelID);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_channel_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        SlackChannelListParams parameters = new()
        {
            SlackWorkspaceID = "slack_workspace_id",
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackChannelID = "slack_channel_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_tag/slack_channels?slack_workspace_id=slack_workspace_id&include_inherited=true&limit=0&page=page&slack_channel_id=slack_channel_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SlackChannelListParams parameters = new()
        {
            SlackWorkspaceID = "slack_workspace_id",
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
        var parameters = new SlackChannelListParams
        {
            SlackWorkspaceID = "slack_workspace_id",
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackChannelID = "slack_channel_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SlackChannelListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

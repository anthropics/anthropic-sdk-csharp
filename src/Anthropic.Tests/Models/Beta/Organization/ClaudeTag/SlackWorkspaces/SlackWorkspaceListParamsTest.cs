using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

public class SlackWorkspaceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SlackWorkspaceListParams
        {
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackWorkspaceID = "slack_workspace_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        bool expectedIncludeInherited = true;
        int expectedLimit = 0;
        string expectedPage = "page";
        string expectedSlackWorkspaceID = "slack_workspace_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedIncludeInherited, parameters.IncludeInherited);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSlackWorkspaceID, parameters.SlackWorkspaceID);
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
        var parameters = new SlackWorkspaceListParams { };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SlackWorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_workspace_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SlackWorkspaceListParams
        {
            // Null should be interpreted as omitted for these properties
            IncludeInherited = null,
            Limit = null,
            Page = null,
            SlackWorkspaceID = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SlackWorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_workspace_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new SlackWorkspaceListParams
        {
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackWorkspaceID = "slack_workspace_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            IncludeInherited = null,
            Limit = null,
            Page = null,
            SlackWorkspaceID = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeInherited);
        Assert.False(parameters.RawQueryData.ContainsKey("include_inherited"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SlackWorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_workspace_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        SlackWorkspaceListParams parameters = new()
        {
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackWorkspaceID = "slack_workspace_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_tag/slack_workspaces?include_inherited=true&limit=0&page=page&slack_workspace_id=slack_workspace_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SlackWorkspaceListParams parameters = new()
        {
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
        var parameters = new SlackWorkspaceListParams
        {
            IncludeInherited = true,
            Limit = 0,
            Page = "page",
            SlackWorkspaceID = "slack_workspace_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SlackWorkspaceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

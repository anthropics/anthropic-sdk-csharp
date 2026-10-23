using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeTag;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

public class SlackWorkspaceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SlackWorkspaceUpdateParams
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ";
        BetaClaudeTagSettingsUpdate expectedSettings = new()
        {
            Enabled = true,
            EnvironmentID = "x",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "x",
        };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSettings, parameters.Settings);
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
        var parameters = new SlackWorkspaceUpdateParams
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SlackWorkspaceUpdateParams
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new SlackWorkspaceUpdateParams
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        SlackWorkspaceUpdateParams parameters = new()
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_tag/slack_workspaces/slws_01Hq8TzW5mKc2YbX7vNd4RfJ"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SlackWorkspaceUpdateParams parameters = new()
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },
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
        var parameters = new SlackWorkspaceUpdateParams
        {
            ID = "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
            Settings = new()
            {
                Enabled = true,
                EnvironmentID = "x",
                GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                Instructions = "instructions",
                Model = "x",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SlackWorkspaceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

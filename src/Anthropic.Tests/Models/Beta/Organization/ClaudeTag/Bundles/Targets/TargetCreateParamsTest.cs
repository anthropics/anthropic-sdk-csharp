using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class TargetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TargetCreateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedBundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq";
        BetaClaudeTagBundleTargetCreate expectedTarget =
            new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx");
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedBundleID, parameters.BundleID);
        Assert.Equal(expectedTarget, parameters.Target);
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
        var parameters = new TargetCreateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TargetCreateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new TargetCreateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),
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
        TargetCreateParams parameters = new()
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_tag/bundles/capp_011CZkZjLP1cWxj5EtMmdgbq/targets"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TargetCreateParams parameters = new()
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),
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
        var parameters = new TargetCreateParams
        {
            BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq",
            Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx"),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        TargetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

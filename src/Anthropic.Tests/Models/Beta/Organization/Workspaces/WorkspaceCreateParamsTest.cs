using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class WorkspaceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceCreateParams
        {
            Name = "x",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = DefaultInferenceGeo.Global,
                WorkspaceGeo = WorkspaceGeo.Us,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedName = "x";
        BetaDataResidencyCreateConfig expectedDataResidency = new()
        {
            AllowedInferenceGeos =
                new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DefaultInferenceGeo.Global,
            WorkspaceGeo = WorkspaceGeo.Us,
        };
        string expectedDisplayColor = "#6C5BB9";
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        Dictionary<string, string> expectedTags = new()
        {
            { "env", "prod" },
            { "team", "platform" },
        };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDataResidency, parameters.DataResidency);
        Assert.Equal(expectedDisplayColor, parameters.DisplayColor);
        Assert.Equal(expectedExternalKeyID, parameters.ExternalKeyID);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(parameters.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Tags[item.Key]);
        }
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
        var parameters = new WorkspaceCreateParams
        {
            Name = "x",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = DefaultInferenceGeo.Global,
                WorkspaceGeo = WorkspaceGeo.Us,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceCreateParams
        {
            Name = "x",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = DefaultInferenceGeo.Global,
                WorkspaceGeo = WorkspaceGeo.Us,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceCreateParams
        {
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DataResidency);
        Assert.False(parameters.RawBodyData.ContainsKey("data_residency"));
        Assert.Null(parameters.DisplayColor);
        Assert.False(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspaceCreateParams
        {
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DataResidency = null,
            DisplayColor = null,
            ExternalKeyID = null,
            Tags = null,
        };

        Assert.Null(parameters.DataResidency);
        Assert.True(parameters.RawBodyData.ContainsKey("data_residency"));
        Assert.Null(parameters.DisplayColor);
        Assert.True(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Tags);
        Assert.True(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceCreateParams parameters = new() { Name = "x" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/workspaces?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkspaceCreateParams parameters = new()
        {
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceCreateParams
        {
            Name = "x",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = DefaultInferenceGeo.Global,
                WorkspaceGeo = WorkspaceGeo.Us,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WorkspaceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

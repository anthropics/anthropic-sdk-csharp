using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class WorkspaceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            InferenceDataPrivacy = new()
            {
                HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
                SafeguardsStorage = new BetaInternalStorageParam(),
                TranscriptsStorage = new BetaInternalStorageParam(),
            },
            Name = "Workspace Name",
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedWorkspaceID = "workspace_id";
        BetaDataResidencyUpdateConfig expectedDataResidency = new()
        {
            AllowedInferenceGeos =
                new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };
        string expectedDisplayColor = "#6C5BB9";
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        BetaInferenceDataPrivacyUpdateParam expectedInferenceDataPrivacy = new()
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        };
        string expectedName = "Workspace Name";
        Dictionary<string, string?> expectedTags = new()
        {
            { "env", "prod" },
            { "team", "platform" },
        };
        string expectedUserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedDataResidency, parameters.DataResidency);
        Assert.Equal(expectedDisplayColor, parameters.DisplayColor);
        Assert.Equal(expectedExternalKeyID, parameters.ExternalKeyID);
        Assert.Equal(expectedInferenceDataPrivacy, parameters.InferenceDataPrivacy);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(parameters.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Tags[item.Key]);
        }
        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
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
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
            },
            InferenceDataPrivacy = new()
            {
                HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
                SafeguardsStorage = new BetaInternalStorageParam(),
                TranscriptsStorage = new BetaInternalStorageParam(),
            },
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
        };

        Assert.Null(parameters.DisplayColor);
        Assert.False(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_profile_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
            },
            InferenceDataPrivacy = new()
            {
                HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
                SafeguardsStorage = new BetaInternalStorageParam(),
                TranscriptsStorage = new BetaInternalStorageParam(),
            },
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },

            // Null should be interpreted as omitted for these properties
            DisplayColor = null,
            ExternalKeyID = null,
            Name = null,
            UserProfileID = null,
            Betas = null,
        };

        Assert.Null(parameters.DisplayColor);
        Assert.False(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_profile_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            InferenceDataPrivacy = new()
            {
                HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
                SafeguardsStorage = new BetaInternalStorageParam(),
                TranscriptsStorage = new BetaInternalStorageParam(),
            },
            Name = "Workspace Name",
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            DisplayColor = null,
            ExternalKeyID = null,
            Name = null,
            UserProfileID = null,
            Betas = null,
        };

        Assert.Null(parameters.DisplayColor);
        Assert.False(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_profile_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.DataResidency);
        Assert.False(parameters.RawBodyData.ContainsKey("data_residency"));
        Assert.Null(parameters.InferenceDataPrivacy);
        Assert.False(parameters.RawBodyData.ContainsKey("inference_data_privacy"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "Workspace Name",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            DataResidency = null,
            InferenceDataPrivacy = null,
            Tags = null,
        };

        Assert.Null(parameters.DataResidency);
        Assert.True(parameters.RawBodyData.ContainsKey("data_residency"));
        Assert.Null(parameters.InferenceDataPrivacy);
        Assert.True(parameters.RawBodyData.ContainsKey("inference_data_privacy"));
        Assert.Null(parameters.Tags);
        Assert.True(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceUpdateParams parameters = new() { WorkspaceID = "workspace_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/workspaces/workspace_id"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkspaceUpdateParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DataResidency = new()
            {
                AllowedInferenceGeos =
                    new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            InferenceDataPrivacy = new()
            {
                HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
                SafeguardsStorage = new BetaInternalStorageParam(),
                TranscriptsStorage = new BetaInternalStorageParam(),
            },
            Name = "Workspace Name",
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        WorkspaceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

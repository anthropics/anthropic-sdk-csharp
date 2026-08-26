using System;
using System.Collections.Generic;
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
            Name = "x",
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
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
        string expectedName = "x";
        Dictionary<string, string?> expectedTags = new()
        {
            { "env", "prod" },
            { "team", "platform" },
        };

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedDataResidency, parameters.DataResidency);
        Assert.Equal(expectedDisplayColor, parameters.DisplayColor);
        Assert.Equal(expectedExternalKeyID, parameters.ExternalKeyID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(parameters.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Tags[item.Key]);
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
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
        };

        Assert.Null(parameters.DisplayColor);
        Assert.False(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
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
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },

            // Null should be interpreted as omitted for these properties
            DisplayColor = null,
            ExternalKeyID = null,
            Name = null,
        };

        Assert.Null(parameters.DisplayColor);
        Assert.False(parameters.RawBodyData.ContainsKey("display_color"));
        Assert.Null(parameters.ExternalKeyID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_key_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceUpdateParams
        {
            WorkspaceID = "workspace_id",
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Name = "x",
        };

        Assert.Null(parameters.DataResidency);
        Assert.False(parameters.RawBodyData.ContainsKey("data_residency"));
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
            Name = "x",

            DataResidency = null,
            Tags = null,
        };

        Assert.Null(parameters.DataResidency);
        Assert.True(parameters.RawBodyData.ContainsKey("data_residency"));
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
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id?beta=true"
                ),
                url
            )
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
            Name = "x",
            Tags = new Dictionary<string, string?>() { { "env", "prod" }, { "team", "platform" } },
        };

        WorkspaceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

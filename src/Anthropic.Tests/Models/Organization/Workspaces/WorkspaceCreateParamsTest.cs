using System;
using System.Collections.Generic;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

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
                    new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
                WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        string expectedName = "x";
        DataResidencyCreateConfig expectedDataResidency = new()
        {
            AllowedInferenceGeos = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
        };
        string expectedDisplayColor = "#6C5BB9";
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        Dictionary<string, string> expectedTags = new()
        {
            { "env", "prod" },
            { "team", "platform" },
        };

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
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceCreateParams { Name = "x" };

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
                new Uri("https://api.anthropic.com/v1/organizations/workspaces"),
                url
            )
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
                    new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
                DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
                WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
            },
            DisplayColor = "#6C5BB9",
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Tags = new Dictionary<string, string>() { { "env", "prod" }, { "team", "platform" } },
        };

        WorkspaceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

public class RbacGroupSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacGroupSetParams
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedRbacGroupID = "rbac_group_id";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedRbacGroupID, parameters.RbacGroupID);
        Assert.Equal(expectedSettings.Count, parameters.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(parameters.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Settings[item.Key]));
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
        var parameters = new RbacGroupSetParams
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RbacGroupSetParams
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
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
        var parameters = new RbacGroupSetParams
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
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
        RbacGroupSetParams parameters = new()
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_code/managed_settings/rbac_groups/rbac_group_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RbacGroupSetParams parameters = new()
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,ce-claude-code-managed-settings-2026-10-06"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RbacGroupSetParams
        {
            RbacGroupID = "rbac_group_id",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        RbacGroupSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

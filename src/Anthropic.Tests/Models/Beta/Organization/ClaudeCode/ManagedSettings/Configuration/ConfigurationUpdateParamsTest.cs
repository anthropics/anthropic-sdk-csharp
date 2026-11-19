using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

public class ConfigurationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConfigurationUpdateParams
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationModeParam(),
            RbacGroupOrder = ["string"],
            RbacGroupOrderVersion = "rbac_group_order_version",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        BetaClaudeCodeManagedSettingsModeParam expectedMode =
            new BetaClaudeCodeManagedSettingsOrganizationModeParam();
        List<string> expectedRbacGroupOrder = ["string"];
        string expectedRbacGroupOrderVersion = "rbac_group_order_version";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedMode, parameters.Mode);
        Assert.NotNull(parameters.RbacGroupOrder);
        Assert.Equal(expectedRbacGroupOrder.Count, parameters.RbacGroupOrder.Count);
        for (int i = 0; i < expectedRbacGroupOrder.Count; i++)
        {
            Assert.Equal(expectedRbacGroupOrder[i], parameters.RbacGroupOrder[i]);
        }
        Assert.Equal(expectedRbacGroupOrderVersion, parameters.RbacGroupOrderVersion);
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
        var parameters = new ConfigurationUpdateParams { };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.RbacGroupOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_order"));
        Assert.Null(parameters.RbacGroupOrderVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_order_version"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConfigurationUpdateParams
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
            RbacGroupOrder = null,
            RbacGroupOrderVersion = null,
            Betas = null,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.RbacGroupOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_order"));
        Assert.Null(parameters.RbacGroupOrderVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_order_version"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ConfigurationUpdateParams
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationModeParam(),
            RbacGroupOrder = ["string"],
            RbacGroupOrderVersion = "rbac_group_order_version",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
            RbacGroupOrder = null,
            RbacGroupOrderVersion = null,
            Betas = null,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.RbacGroupOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_order"));
        Assert.Null(parameters.RbacGroupOrderVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_order_version"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        ConfigurationUpdateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/claude_code/managed_settings/configuration"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ConfigurationUpdateParams parameters = new()
        {
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
        var parameters = new ConfigurationUpdateParams
        {
            Mode = new BetaClaudeCodeManagedSettingsOrganizationModeParam(),
            RbacGroupOrder = ["string"],
            RbacGroupOrderVersion = "rbac_group_order_version",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        ConfigurationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

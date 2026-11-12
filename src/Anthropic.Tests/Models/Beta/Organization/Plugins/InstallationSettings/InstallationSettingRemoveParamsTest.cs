using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.InstallationSettings;

public class InstallationSettingRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InstallationSettingRemoveParams
        {
            PluginID = "plugin_id",
            Target = "target",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedPluginID = "plugin_id";
        string expectedTarget = "target";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedPluginID, parameters.PluginID);
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
        var parameters = new InstallationSettingRemoveParams
        {
            PluginID = "plugin_id",
            Target = "target",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InstallationSettingRemoveParams
        {
            PluginID = "plugin_id",
            Target = "target",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new InstallationSettingRemoveParams
        {
            PluginID = "plugin_id",
            Target = "target",
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
        InstallationSettingRemoveParams parameters = new()
        {
            PluginID = "plugin_id",
            Target = "target",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugins/plugin_id/installation_settings/target"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        InstallationSettingRemoveParams parameters = new()
        {
            PluginID = "plugin_id",
            Target = "target",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InstallationSettingRemoveParams
        {
            PluginID = "plugin_id",
            Target = "target",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        InstallationSettingRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

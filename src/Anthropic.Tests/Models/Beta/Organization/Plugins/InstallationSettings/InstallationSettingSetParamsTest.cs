using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.InstallationSettings;

public class InstallationSettingSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InstallationSettingSetParams
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedPluginID = "plugin_id";
        string expectedTarget = "target";
        ApiEnum<string, InstallationPreference> expectedInstallationPreference =
            InstallationPreference.Required;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedPluginID, parameters.PluginID);
        Assert.Equal(expectedTarget, parameters.Target);
        Assert.Equal(expectedInstallationPreference, parameters.InstallationPreference);
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
        var parameters = new InstallationSettingSetParams
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InstallationSettingSetParams
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new InstallationSettingSetParams
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,
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
        InstallationSettingSetParams parameters = new()
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,
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
        InstallationSettingSetParams parameters = new()
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,
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
        var parameters = new InstallationSettingSetParams
        {
            PluginID = "plugin_id",
            Target = "target",
            InstallationPreference = InstallationPreference.Required,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        InstallationSettingSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InstallationPreferenceTest : TestBase
{
    [Theory]
    [InlineData(InstallationPreference.AutoInstall)]
    [InlineData(InstallationPreference.Available)]
    [InlineData(InstallationPreference.NotAvailable)]
    [InlineData(InstallationPreference.Required)]
    public void Validation_Works(InstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InstallationPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InstallationPreference>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InstallationPreference.AutoInstall, 0, "auto_install")]
    [InlineData(InstallationPreference.Available, 1, "available")]
    [InlineData(InstallationPreference.NotAvailable, 2, "not_available")]
    [InlineData(InstallationPreference.Required, 3, "required")]
    public void EnumMemberSerializationRoundtrip_Works(
        InstallationPreference rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InstallationPreference> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InstallationPreference>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InstallationPreference>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InstallationPreference>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

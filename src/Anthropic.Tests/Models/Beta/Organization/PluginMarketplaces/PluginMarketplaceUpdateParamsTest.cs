using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class PluginMarketplaceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PluginMarketplaceUpdateParams
        {
            MarketplaceID = "marketplace_id",
            DefaultInstallationPreference = DefaultInstallationPreference.Available,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMarketplaceID = "marketplace_id";
        ApiEnum<string, DefaultInstallationPreference> expectedDefaultInstallationPreference =
            DefaultInstallationPreference.Available;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMarketplaceID, parameters.MarketplaceID);
        Assert.Equal(
            expectedDefaultInstallationPreference,
            parameters.DefaultInstallationPreference
        );
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
        var parameters = new PluginMarketplaceUpdateParams
        {
            MarketplaceID = "marketplace_id",
            DefaultInstallationPreference = DefaultInstallationPreference.Available,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PluginMarketplaceUpdateParams
        {
            MarketplaceID = "marketplace_id",
            DefaultInstallationPreference = DefaultInstallationPreference.Available,

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginMarketplaceUpdateParams parameters = new()
        {
            MarketplaceID = "marketplace_id",
            DefaultInstallationPreference = DefaultInstallationPreference.Available,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugin_marketplaces/marketplace_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PluginMarketplaceUpdateParams parameters = new()
        {
            MarketplaceID = "marketplace_id",
            DefaultInstallationPreference = DefaultInstallationPreference.Available,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PluginMarketplaceUpdateParams
        {
            MarketplaceID = "marketplace_id",
            DefaultInstallationPreference = DefaultInstallationPreference.Available,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        PluginMarketplaceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DefaultInstallationPreferenceTest : TestBase
{
    [Theory]
    [InlineData(DefaultInstallationPreference.AutoInstall)]
    [InlineData(DefaultInstallationPreference.Available)]
    [InlineData(DefaultInstallationPreference.NotAvailable)]
    [InlineData(DefaultInstallationPreference.Required)]
    public void Validation_Works(DefaultInstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DefaultInstallationPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DefaultInstallationPreference>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DefaultInstallationPreference.AutoInstall)]
    [InlineData(DefaultInstallationPreference.Available)]
    [InlineData(DefaultInstallationPreference.NotAvailable)]
    [InlineData(DefaultInstallationPreference.Required)]
    public void SerializationRoundtrip_Works(DefaultInstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DefaultInstallationPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DefaultInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DefaultInstallationPreference>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DefaultInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

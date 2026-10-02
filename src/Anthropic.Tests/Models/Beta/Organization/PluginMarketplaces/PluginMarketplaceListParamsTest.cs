using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class PluginMarketplaceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PluginMarketplaceListParams
        {
            Limit = 1,
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            Page = "page",
            Source = Source.Directory,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        long expectedLimit = 1;
        string expectedOrganizationID = "organization_id";
        ApiEnum<string, OwnerType> expectedOwnerType = OwnerType.Organization;
        string expectedPage = "page";
        ApiEnum<string, Source> expectedSource = Source.Directory;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedOwnerType, parameters.OwnerType);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSource, parameters.Source);
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
        var parameters = new PluginMarketplaceListParams
        {
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            Page = "page",
            Source = Source.Directory,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PluginMarketplaceListParams
        {
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            Page = "page",
            Source = Source.Directory,

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PluginMarketplaceListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.OwnerType);
        Assert.False(parameters.RawQueryData.ContainsKey("owner_type"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Source);
        Assert.False(parameters.RawQueryData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PluginMarketplaceListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            OrganizationID = null,
            OwnerType = null,
            Page = null,
            Source = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.OwnerType);
        Assert.True(parameters.RawQueryData.ContainsKey("owner_type"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Source);
        Assert.True(parameters.RawQueryData.ContainsKey("source"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginMarketplaceListParams parameters = new()
        {
            Limit = 1,
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            Page = "page",
            Source = Source.Directory,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugin_marketplaces?beta=true&limit=1&organization_id=organization_id&owner_type=organization&page=page&source=directory"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PluginMarketplaceListParams parameters = new()
        {
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
        var parameters = new PluginMarketplaceListParams
        {
            Limit = 1,
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            Page = "page",
            Source = Source.Directory,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        PluginMarketplaceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OwnerTypeTest : TestBase
{
    [Theory]
    [InlineData(OwnerType.Organization)]
    [InlineData(OwnerType.User)]
    public void Validation_Works(OwnerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OwnerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OwnerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OwnerType.Organization)]
    [InlineData(OwnerType.User)]
    public void SerializationRoundtrip_Works(OwnerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OwnerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OwnerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OwnerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OwnerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Directory)]
    [InlineData(Source.GitHub)]
    [InlineData(Source.Gitlab)]
    [InlineData(Source.Manual)]
    [InlineData(Source.PublicGit)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Directory)]
    [InlineData(Source.GitHub)]
    [InlineData(Source.Gitlab)]
    [InlineData(Source.Manual)]
    [InlineData(Source.PublicGit)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

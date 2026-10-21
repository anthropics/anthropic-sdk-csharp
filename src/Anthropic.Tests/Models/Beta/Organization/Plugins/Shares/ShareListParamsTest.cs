using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins.Shares;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.Shares;

public class ShareListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            TargetType = TargetType.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedPluginID = "plugin_id";
        long expectedLimit = 1;
        string expectedOrganizationID = "organization_id";
        string expectedPage = "page";
        ApiEnum<string, TargetType> expectedTargetType = TargetType.Organization;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedPluginID, parameters.PluginID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedTargetType, parameters.TargetType);
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
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            OrganizationID = "organization_id",
            Page = "page",
            TargetType = TargetType.Organization,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            OrganizationID = "organization_id",
            Page = "page",
            TargetType = TargetType.Organization,

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
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            TargetType = TargetType.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
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
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.TargetType);
        Assert.False(parameters.RawQueryData.ContainsKey("target_type"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            OrganizationID = null,
            Page = null,
            TargetType = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.TargetType);
        Assert.True(parameters.RawQueryData.ContainsKey("target_type"));
    }

    [Fact]
    public void Url_Works()
    {
        ShareListParams parameters = new()
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            TargetType = TargetType.Organization,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugins/plugin_id/shares?beta=true&limit=1&organization_id=organization_id&page=page&target_type=organization"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ShareListParams parameters = new()
        {
            PluginID = "plugin_id",
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
        var parameters = new ShareListParams
        {
            PluginID = "plugin_id",
            Limit = 1,
            OrganizationID = "organization_id",
            Page = "page",
            TargetType = TargetType.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        ShareListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TargetTypeTest : TestBase
{
    [Theory]
    [InlineData(TargetType.Organization)]
    [InlineData(TargetType.OrganizationMember)]
    [InlineData(TargetType.RbacGroup)]
    public void Validation_Works(TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TargetType.Organization)]
    [InlineData(TargetType.OrganizationMember)]
    [InlineData(TargetType.RbacGroup)]
    public void SerializationRoundtrip_Works(TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

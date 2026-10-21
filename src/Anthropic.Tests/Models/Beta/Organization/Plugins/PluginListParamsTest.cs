using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class PluginListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PluginListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            MarketplaceID = "marketplace_id",
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            OwnerUserID = "owner_user_id",
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedLimit = 1;
        string expectedMarketplaceID = "marketplace_id";
        string expectedOrganizationID = "organization_id";
        ApiEnum<string, OwnerType> expectedOwnerType = OwnerType.Organization;
        string expectedOwnerUserID = "owner_user_id";
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMarketplaceID, parameters.MarketplaceID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedOwnerType, parameters.OwnerType);
        Assert.Equal(expectedOwnerUserID, parameters.OwnerUserID);
        Assert.Equal(expectedPage, parameters.Page);
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
        var parameters = new PluginListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MarketplaceID = "marketplace_id",
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            OwnerUserID = "owner_user_id",
            Page = "page",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PluginListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MarketplaceID = "marketplace_id",
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            OwnerUserID = "owner_user_id",
            Page = "page",

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
        var parameters = new PluginListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            MarketplaceID = "marketplace_id",
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            OwnerUserID = "owner_user_id",
            Page = "page",
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
        var parameters = new PluginListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.MarketplaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("marketplace_id"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.OwnerType);
        Assert.False(parameters.RawQueryData.ContainsKey("owner_type"));
        Assert.Null(parameters.OwnerUserID);
        Assert.False(parameters.RawQueryData.ContainsKey("owner_user_id"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PluginListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            MarketplaceID = null,
            OrganizationID = null,
            OwnerType = null,
            OwnerUserID = null,
            Page = null,
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.MarketplaceID);
        Assert.True(parameters.RawQueryData.ContainsKey("marketplace_id"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.OwnerType);
        Assert.True(parameters.RawQueryData.ContainsKey("owner_type"));
        Assert.Null(parameters.OwnerUserID);
        Assert.True(parameters.RawQueryData.ContainsKey("owner_user_id"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginListParams parameters = new()
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Limit = 1,
            MarketplaceID = "marketplace_id",
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            OwnerUserID = "owner_user_id",
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugins?beta=true&created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=1&marketplace_id=marketplace_id&organization_id=organization_id&owner_type=organization&owner_user_id=owner_user_id&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PluginListParams parameters = new() { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PluginListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            MarketplaceID = "marketplace_id",
            OrganizationID = "organization_id",
            OwnerType = OwnerType.Organization,
            OwnerUserID = "owner_user_id",
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        PluginListParams copied = new(parameters);

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

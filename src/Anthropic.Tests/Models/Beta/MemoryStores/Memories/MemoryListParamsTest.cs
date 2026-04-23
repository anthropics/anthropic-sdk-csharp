using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class MemoryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryListParams
        {
            MemoryStoreID = "memory_store_id",
            Depth = 0,
            Limit = 0,
            Order = Order.Asc,
            OrderBy = "order_by",
            Page = "page",
            PathPrefix = "path_prefix",
            View = BetaManagedAgentsMemoryView.Basic,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMemoryStoreID = "memory_store_id";
        int expectedDepth = 0;
        int expectedLimit = 0;
        ApiEnum<string, Order> expectedOrder = Order.Asc;
        string expectedOrderBy = "order_by";
        string expectedPage = "page";
        string expectedPathPrefix = "path_prefix";
        ApiEnum<string, BetaManagedAgentsMemoryView> expectedView =
            BetaManagedAgentsMemoryView.Basic;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
        Assert.Equal(expectedDepth, parameters.Depth);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPathPrefix, parameters.PathPrefix);
        Assert.Equal(expectedView, parameters.View);
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
        var parameters = new MemoryListParams { MemoryStoreID = "memory_store_id" };

        Assert.Null(parameters.Depth);
        Assert.False(parameters.RawQueryData.ContainsKey("depth"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PathPrefix);
        Assert.False(parameters.RawQueryData.ContainsKey("path_prefix"));
        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryListParams
        {
            MemoryStoreID = "memory_store_id",

            // Null should be interpreted as omitted for these properties
            Depth = null,
            Limit = null,
            Order = null,
            OrderBy = null,
            Page = null,
            PathPrefix = null,
            View = null,
            Betas = null,
        };

        Assert.Null(parameters.Depth);
        Assert.False(parameters.RawQueryData.ContainsKey("depth"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PathPrefix);
        Assert.False(parameters.RawQueryData.ContainsKey("path_prefix"));
        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryListParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            Depth = 0,
            Limit = 0,
            Order = Order.Asc,
            OrderBy = "order_by",
            Page = "page",
            PathPrefix = "path_prefix",
            View = BetaManagedAgentsMemoryView.Basic,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/memory_stores/memory_store_id/memories?beta=true&depth=0&limit=0&order=asc&order_by=order_by&page=page&path_prefix=path_prefix&view=basic"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MemoryListParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemoryListParams
        {
            MemoryStoreID = "memory_store_id",
            Depth = 0,
            Limit = 0,
            Order = Order.Asc,
            OrderBy = "order_by",
            Page = "page",
            PathPrefix = "path_prefix",
            View = BetaManagedAgentsMemoryView.Basic,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MemoryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OrderTest : TestBase
{
    [Theory]
    [InlineData(Order.Asc)]
    [InlineData(Order.Desc)]
    public void Validation_Works(Order rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Order> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Order.Asc)]
    [InlineData(Order.Desc)]
    public void SerializationRoundtrip_Works(Order rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Order> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

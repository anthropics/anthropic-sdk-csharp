using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class WebhookListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 0,
            Order = Order.Asc,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        long expectedLimit = 0;
        ApiEnum<string, Order> expectedOrder = Order.Asc;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
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
        var parameters = new WebhookListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Order = Order.Asc,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Order = Order.Asc,

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
        var parameters = new WebhookListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 0,
            Order = Order.Asc,
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
        var parameters = new WebhookListParams
        {
            Limit = 0,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookListParams
        {
            Limit = 0,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            AfterID = null,
            BeforeID = null,
            Order = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.True(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.True(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Order);
        Assert.True(parameters.RawQueryData.ContainsKey("order"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 0,
            Order = Order.Asc,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/webhooks?after_id=after_id&before_id=before_id&limit=0&order=asc"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookListParams parameters = new() { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,webhooks-2026-10-07"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 0,
            Order = Order.Asc,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WebhookListParams copied = new(parameters);

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

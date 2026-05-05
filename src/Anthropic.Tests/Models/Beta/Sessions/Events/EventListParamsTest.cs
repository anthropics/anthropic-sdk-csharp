using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class EventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventListParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = Order.Asc,
            Page = "page",
            Types = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedLimit = 0;
        ApiEnum<string, Order> expectedOrder = Order.Asc;
        string expectedPage = "page";
        List<string> expectedTypes = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Types);
        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
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
        var parameters = new EventListParams { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventListParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",

            // Null should be interpreted as omitted for these properties
            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Limit = null,
            Order = null,
            Page = null,
            Types = null,
            Betas = null,
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        EventListParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Limit = 0,
            Order = Order.Asc,
            Page = "page",
            Types = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/sessions/sesn_011CZkZAtmR3yMPDzynEDxu7/events?beta=true&created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=0&order=asc&page=page&types%5b%5d=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EventListParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
        var parameters = new EventListParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = Order.Asc,
            Page = "page",
            Types = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        EventListParams copied = new(parameters);

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

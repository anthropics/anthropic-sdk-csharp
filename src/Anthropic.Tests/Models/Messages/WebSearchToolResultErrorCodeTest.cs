using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(WebSearchToolResultErrorCode.InvalidToolInput)]
    [InlineData(WebSearchToolResultErrorCode.Unavailable)]
    [InlineData(WebSearchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(WebSearchToolResultErrorCode.TooManyRequests)]
    [InlineData(WebSearchToolResultErrorCode.QueryTooLong)]
    [InlineData(WebSearchToolResultErrorCode.RequestTooLarge)]
    public void Validation_Works(WebSearchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebSearchToolResultErrorCode.InvalidToolInput, 0, "invalid_tool_input")]
    [InlineData(WebSearchToolResultErrorCode.Unavailable, 1, "unavailable")]
    [InlineData(WebSearchToolResultErrorCode.MaxUsesExceeded, 2, "max_uses_exceeded")]
    [InlineData(WebSearchToolResultErrorCode.TooManyRequests, 3, "too_many_requests")]
    [InlineData(WebSearchToolResultErrorCode.QueryTooLong, 4, "query_too_long")]
    [InlineData(WebSearchToolResultErrorCode.RequestTooLarge, 5, "request_too_large")]
    public void EnumMemberSerializationRoundtrip_Works(
        WebSearchToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaWebSearchToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaWebSearchToolResultErrorCode.Unavailable)]
    [InlineData(BetaWebSearchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(BetaWebSearchToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaWebSearchToolResultErrorCode.QueryTooLong)]
    [InlineData(BetaWebSearchToolResultErrorCode.RequestTooLarge)]
    public void Validation_Works(BetaWebSearchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWebSearchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebSearchToolResultErrorCode.InvalidToolInput, 0, "invalid_tool_input")]
    [InlineData(BetaWebSearchToolResultErrorCode.Unavailable, 1, "unavailable")]
    [InlineData(BetaWebSearchToolResultErrorCode.MaxUsesExceeded, 2, "max_uses_exceeded")]
    [InlineData(BetaWebSearchToolResultErrorCode.TooManyRequests, 3, "too_many_requests")]
    [InlineData(BetaWebSearchToolResultErrorCode.QueryTooLong, 4, "query_too_long")]
    [InlineData(BetaWebSearchToolResultErrorCode.RequestTooLarge, 5, "request_too_large")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaWebSearchToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWebSearchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

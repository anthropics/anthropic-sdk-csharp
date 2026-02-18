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
    [InlineData(WebSearchToolResultErrorCode.InvalidToolInput)]
    [InlineData(WebSearchToolResultErrorCode.Unavailable)]
    [InlineData(WebSearchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(WebSearchToolResultErrorCode.TooManyRequests)]
    [InlineData(WebSearchToolResultErrorCode.QueryTooLong)]
    [InlineData(WebSearchToolResultErrorCode.RequestTooLarge)]
    public void SerializationRoundtrip_Works(WebSearchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

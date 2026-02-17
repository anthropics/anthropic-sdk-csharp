using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(WebFetchToolResultErrorCode.InvalidToolInput)]
    [InlineData(WebFetchToolResultErrorCode.UrlTooLong)]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAllowed)]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAccessible)]
    [InlineData(WebFetchToolResultErrorCode.UnsupportedContentType)]
    [InlineData(WebFetchToolResultErrorCode.TooManyRequests)]
    [InlineData(WebFetchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(WebFetchToolResultErrorCode.Unavailable)]
    public void Validation_Works(WebFetchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebFetchToolResultErrorCode.InvalidToolInput)]
    [InlineData(WebFetchToolResultErrorCode.UrlTooLong)]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAllowed)]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAccessible)]
    [InlineData(WebFetchToolResultErrorCode.UnsupportedContentType)]
    [InlineData(WebFetchToolResultErrorCode.TooManyRequests)]
    [InlineData(WebFetchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(WebFetchToolResultErrorCode.Unavailable)]
    public void SerializationRoundtrip_Works(WebFetchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

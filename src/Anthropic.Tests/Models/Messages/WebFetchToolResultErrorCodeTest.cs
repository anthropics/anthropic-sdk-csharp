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
    [InlineData(WebFetchToolResultErrorCode.UrlNotInPriorContext)]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAccessible)]
    [InlineData(WebFetchToolResultErrorCode.UnsupportedContentType)]
    [InlineData(WebFetchToolResultErrorCode.TooManyRequests)]
    [InlineData(WebFetchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(WebFetchToolResultErrorCode.Unavailable)]
    [InlineData(WebFetchToolResultErrorCode.ContentTooLarge)]
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
    [InlineData(WebFetchToolResultErrorCode.InvalidToolInput, 0, "invalid_tool_input")]
    [InlineData(WebFetchToolResultErrorCode.UrlTooLong, 1, "url_too_long")]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAllowed, 2, "url_not_allowed")]
    [InlineData(WebFetchToolResultErrorCode.UrlNotInPriorContext, 3, "url_not_in_prior_context")]
    [InlineData(WebFetchToolResultErrorCode.UrlNotAccessible, 4, "url_not_accessible")]
    [InlineData(WebFetchToolResultErrorCode.UnsupportedContentType, 5, "unsupported_content_type")]
    [InlineData(WebFetchToolResultErrorCode.TooManyRequests, 6, "too_many_requests")]
    [InlineData(WebFetchToolResultErrorCode.MaxUsesExceeded, 7, "max_uses_exceeded")]
    [InlineData(WebFetchToolResultErrorCode.Unavailable, 8, "unavailable")]
    [InlineData(WebFetchToolResultErrorCode.ContentTooLarge, 9, "content_too_large")]
    public void EnumMemberSerializationRoundtrip_Works(
        WebFetchToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultErrorCode>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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

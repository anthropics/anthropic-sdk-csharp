using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaWebFetchToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlTooLong)]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlNotAllowed)]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlNotInPriorContext)]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlNotAccessible)]
    [InlineData(BetaWebFetchToolResultErrorCode.UnsupportedContentType)]
    [InlineData(BetaWebFetchToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaWebFetchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(BetaWebFetchToolResultErrorCode.Unavailable)]
    [InlineData(BetaWebFetchToolResultErrorCode.ContentTooLarge)]
    public void Validation_Works(BetaWebFetchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWebFetchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebFetchToolResultErrorCode.InvalidToolInput, 0, "invalid_tool_input")]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlTooLong, 1, "url_too_long")]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlNotAllowed, 2, "url_not_allowed")]
    [InlineData(
        BetaWebFetchToolResultErrorCode.UrlNotInPriorContext,
        3,
        "url_not_in_prior_context"
    )]
    [InlineData(BetaWebFetchToolResultErrorCode.UrlNotAccessible, 4, "url_not_accessible")]
    [InlineData(
        BetaWebFetchToolResultErrorCode.UnsupportedContentType,
        5,
        "unsupported_content_type"
    )]
    [InlineData(BetaWebFetchToolResultErrorCode.TooManyRequests, 6, "too_many_requests")]
    [InlineData(BetaWebFetchToolResultErrorCode.MaxUsesExceeded, 7, "max_uses_exceeded")]
    [InlineData(BetaWebFetchToolResultErrorCode.Unavailable, 8, "unavailable")]
    [InlineData(BetaWebFetchToolResultErrorCode.ContentTooLarge, 9, "content_too_large")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaWebFetchToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWebFetchToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

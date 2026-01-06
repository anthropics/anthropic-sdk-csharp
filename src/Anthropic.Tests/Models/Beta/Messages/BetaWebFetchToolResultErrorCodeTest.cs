using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaWebFetchToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaWebFetchToolResultErrorCode.URLTooLong)]
    [InlineData(BetaWebFetchToolResultErrorCode.URLNotAllowed)]
    [InlineData(BetaWebFetchToolResultErrorCode.URLNotAccessible)]
    [InlineData(BetaWebFetchToolResultErrorCode.UnsupportedContentType)]
    [InlineData(BetaWebFetchToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaWebFetchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(BetaWebFetchToolResultErrorCode.Unavailable)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebFetchToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaWebFetchToolResultErrorCode.URLTooLong)]
    [InlineData(BetaWebFetchToolResultErrorCode.URLNotAllowed)]
    [InlineData(BetaWebFetchToolResultErrorCode.URLNotAccessible)]
    [InlineData(BetaWebFetchToolResultErrorCode.UnsupportedContentType)]
    [InlineData(BetaWebFetchToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaWebFetchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(BetaWebFetchToolResultErrorCode.Unavailable)]
    public void SerializationRoundtrip_Works(BetaWebFetchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWebFetchToolResultErrorCode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

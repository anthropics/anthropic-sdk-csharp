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
    [InlineData(BetaWebSearchToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaWebSearchToolResultErrorCode.Unavailable)]
    [InlineData(BetaWebSearchToolResultErrorCode.MaxUsesExceeded)]
    [InlineData(BetaWebSearchToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaWebSearchToolResultErrorCode.QueryTooLong)]
    public void SerializationRoundtrip_Works(BetaWebSearchToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

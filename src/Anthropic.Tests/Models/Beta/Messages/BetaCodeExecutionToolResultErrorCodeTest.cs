using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaCodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaCodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(BetaCodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaCodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    public void Validation_Works(BetaCodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaCodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(BetaCodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(BetaCodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(BetaCodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    public void SerializationRoundtrip_Works(BetaCodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

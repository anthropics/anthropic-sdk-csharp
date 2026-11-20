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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaCodeExecutionToolResultErrorCode.InvalidToolInput, 0, "invalid_tool_input")]
    [InlineData(BetaCodeExecutionToolResultErrorCode.Unavailable, 1, "unavailable")]
    [InlineData(BetaCodeExecutionToolResultErrorCode.TooManyRequests, 2, "too_many_requests")]
    [InlineData(
        BetaCodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
        3,
        "execution_time_exceeded"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaCodeExecutionToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

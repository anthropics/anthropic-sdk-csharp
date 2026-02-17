using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CodeExecutionToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(CodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(CodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(CodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(CodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    public void Validation_Works(CodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CodeExecutionToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CodeExecutionToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(CodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(CodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(CodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    public void SerializationRoundtrip_Works(CodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CodeExecutionToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CodeExecutionToolResultErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

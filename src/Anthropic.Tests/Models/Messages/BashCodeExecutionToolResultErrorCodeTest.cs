using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BashCodeExecutionToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BashCodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(BashCodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(BashCodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(BashCodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    [InlineData(BashCodeExecutionToolResultErrorCode.OutputFileTooLarge)]
    public void Validation_Works(BashCodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BashCodeExecutionToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BashCodeExecutionToolResultErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BashCodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(BashCodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(BashCodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(BashCodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    [InlineData(BashCodeExecutionToolResultErrorCode.OutputFileTooLarge)]
    public void SerializationRoundtrip_Works(BashCodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BashCodeExecutionToolResultErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BashCodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BashCodeExecutionToolResultErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BashCodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

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
    [InlineData(CodeExecutionToolResultErrorCode.InvalidToolInput, 0, "invalid_tool_input")]
    [InlineData(CodeExecutionToolResultErrorCode.Unavailable, 1, "unavailable")]
    [InlineData(CodeExecutionToolResultErrorCode.TooManyRequests, 2, "too_many_requests")]
    [InlineData(
        CodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
        3,
        "execution_time_exceeded"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        CodeExecutionToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CodeExecutionToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionToolResultErrorCode>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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

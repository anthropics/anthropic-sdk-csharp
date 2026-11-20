using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionToolResultErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput)]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.Unavailable)]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.TooManyRequests)]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.ExecutionTimeExceeded)]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.FileNotFound)]
    public void Validation_Works(TextEditorCodeExecutionToolResultErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
        0,
        "invalid_tool_input"
    )]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.Unavailable, 1, "unavailable")]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.TooManyRequests, 2, "too_many_requests")]
    [InlineData(
        TextEditorCodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
        3,
        "execution_time_exceeded"
    )]
    [InlineData(TextEditorCodeExecutionToolResultErrorCode.FileNotFound, 4, "file_not_found")]
    public void EnumMemberSerializationRoundtrip_Works(
        TextEditorCodeExecutionToolResultErrorCode rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode>
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
            ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultError
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> expectedErrorCode =
            BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultError
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultError
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> expectedErrorCode =
            BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultError
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }
}

public class BetaTextEditorCodeExecutionToolResultErrorErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.Unavailable)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.FileNotFound)]
    public void Validation_Works(BetaTextEditorCodeExecutionToolResultErrorErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.Unavailable)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded)]
    [InlineData(BetaTextEditorCodeExecutionToolResultErrorErrorCode.FileNotFound)]
    public void SerializationRoundtrip_Works(
        BetaTextEditorCodeExecutionToolResultErrorErrorCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

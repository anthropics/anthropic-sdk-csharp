using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionToolResultError
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> expectedErrorCode =
            TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput;
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
        var model = new TextEditorCodeExecutionToolResultError
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextEditorCodeExecutionToolResultError
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> expectedErrorCode =
            TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput;
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
        var model = new TextEditorCodeExecutionToolResultError
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextEditorCodeExecutionToolResultError
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        TextEditorCodeExecutionToolResultError copied = new(model);

        Assert.Equal(model, copied);
    }
}

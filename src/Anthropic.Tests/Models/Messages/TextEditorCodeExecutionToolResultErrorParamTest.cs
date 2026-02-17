using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> expectedErrorCode =
            TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultErrorParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultErrorParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> expectedErrorCode =
            TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,

            ErrorMessage = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,

            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        TextEditorCodeExecutionToolResultErrorParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

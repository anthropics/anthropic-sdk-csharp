using System.Text.Json;
using Anthropic.Core;
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
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
            json
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
            json
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> expectedErrorCode =
            BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
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

using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionToolResultErrorParam
        {
            ErrorCode = CodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        ApiEnum<string, CodeExecutionToolResultErrorCode> expectedErrorCode =
            CodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CodeExecutionToolResultErrorParam
        {
            ErrorCode = CodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultErrorParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionToolResultErrorParam
        {
            ErrorCode = CodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultErrorParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CodeExecutionToolResultErrorCode> expectedErrorCode =
            CodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CodeExecutionToolResultErrorParam
        {
            ErrorCode = CodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CodeExecutionToolResultErrorParam
        {
            ErrorCode = CodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        CodeExecutionToolResultErrorParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

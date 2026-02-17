using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BashCodeExecutionToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BashCodeExecutionToolResultError
        {
            ErrorCode = BashCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        ApiEnum<string, BashCodeExecutionToolResultErrorCode> expectedErrorCode =
            BashCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "bash_code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BashCodeExecutionToolResultError
        {
            ErrorCode = BashCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BashCodeExecutionToolResultError
        {
            ErrorCode = BashCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BashCodeExecutionToolResultErrorCode> expectedErrorCode =
            BashCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "bash_code_execution_tool_result_error"
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BashCodeExecutionToolResultError
        {
            ErrorCode = BashCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BashCodeExecutionToolResultError
        {
            ErrorCode = BashCodeExecutionToolResultErrorCode.InvalidToolInput,
        };

        BashCodeExecutionToolResultError copied = new(model);

        Assert.Equal(model, copied);
    }
}
